using System.Collections.Generic;
using System.Linq;
using Core.GlobalServices.ConfigService;
using Core.GlobalServices.ConfigService.Config;
using Core.GlobalServices.LogService;
using Extensions;
using Game.Factory;
using UnityEngine;
using VContainer.Unity;
using Random = UnityEngine.Random;

namespace Game.ChunkSystem
{
    public class LevelController : ILevelController, IFixedTickable
    {
        private readonly GameConfigsSO _gameConfigs;
        private readonly IGameFactory _gameFactory;
        private readonly ILogGlobalService _logGlobalService;

        private Transform _playerTransform;
        private ChunkController _lastChunk;
        private List<ChunkController> _chunks;
        private bool _canCheckChunksSpawn = true;
        
        public LevelController(GameConfigsSO gameConfigs, IGameFactory gameFactory, ILogGlobalService logGlobalService)
        {
            _gameConfigs = gameConfigs;
            _gameFactory = gameFactory;
            _logGlobalService = logGlobalService;
        }

        public void Initialize(Transform playTransform)
        {
            _playerTransform = playTransform;
            _chunks = new List<ChunkController>();
            SpawnInitialChunks();
        }

        public void Dispose()
        {
            foreach (var chunk in _chunks)
            {
                chunk.Dispose();
            }
            _chunks.Clear();
            _lastChunk = null;
        }
        
        public void FixedTick()
        {
            if(_canCheckChunksSpawn)
                TrySpawnNextChunks();
        }
        
        private void SpawnInitialChunks()
        {
            var prefab = _gameConfigs.ChunkBehavioursPrefabs[Random.Range(0, _gameConfigs.ChunkBehavioursPrefabs.Count)];
            _lastChunk = _gameFactory.CreateChunk(prefab);
            _lastChunk.transform.position = _gameConfigs.FirsChunkPosition;
            _chunks.Add(_lastChunk);
            
            SpawnChunksSection();
        }

        private void TrySpawnNextChunks()
        {
            var z = _playerTransform.position.z;
            if (z + _gameConfigs.SpawnTriggerDistance > _lastChunk.EndPoint.position.z)
            {
                SpawnChunksSection();
            }
        }

        private void SpawnChunk()
        {
            if (_lastChunk == null)
            {
                _logGlobalService.LogError($"Last chunk is null!");
                return;
            }
            
            var prefab = _gameConfigs.ChunkBehavioursPrefabs[Random.Range(0, _gameConfigs.ChunkBehavioursPrefabs.Count)];
            var chunk = _gameFactory.CreateChunk(prefab);
            chunk.Initialize();
            
            if (chunk.StartPoint == null || chunk.EndPoint == null)
            {
                _logGlobalService.LogError($"Chunk {chunk.name} is missing StartPoint or EndPoint!");
                chunk.Dispose();
                return;
            }
            
            var offset = chunk.transform.position - chunk.StartPoint.position;
            chunk.transform.position = _lastChunk.EndPoint.position + offset;
            
            _lastChunk = chunk;
            _chunks.Add(_lastChunk);
            TrySpawnFruit(_lastChunk);
        }

        private void SpawnChunksSection()
        {
            for (var i = 0; i < _gameConfigs.ChunksPerSpawn; i++)
            {
                SpawnChunk();
            }
        }

        private void TrySpawnFruit(ChunkController chunkController)
        {
            if (Random.value > _gameConfigs.FruitSpawnChance)
                return;
            
            var totalWeight = _gameConfigs.FruitConfigs.Sum(config => config.spawnChanceWeight);

            var randomWeight = Random.Range(0, totalWeight);
            var currentWeight = 0;

            var fruitConfig = _gameConfigs.FruitConfigs[0];

            foreach (var config in _gameConfigs.FruitConfigs)
            {
                currentWeight += config.spawnChanceWeight;
                if (randomWeight >= currentWeight) 
                    continue;
                
                fruitConfig = config;
                break;
            }

            var parent = chunkController.FruitsSpawnPoints.GetRandomItem();
            _gameFactory.CreateFruit(fruitConfig, parent);
        }

    }
}