using Core.GlobalServices.ConfigService;
using Core.GlobalServices.ConfigService.Config;
using Game.ChunkSystem;
using Game.Collectable;
using Game.Obstacle;
using Game.Player;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Game.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly GameConfigsSO _configs;
        private readonly IObjectResolver _objectResolver;

        public GameFactory(GameConfigsSO configs, IObjectResolver objectResolver)
        {
            _configs = configs;
            _objectResolver = objectResolver;
        }

        public PlayerController CreatePlayer()
        {
            var instance = Object.Instantiate(_configs.PlayerControllerPrefab, _configs.PlayerPosition, Quaternion.identity);
            _objectResolver.InjectGameObject(instance.gameObject);
            return instance;
        }

        public ChunkController CreateChunk(ChunkController chunkPrefab)
        {
            var instance = Object.Instantiate(chunkPrefab);
            _objectResolver.InjectGameObject(instance.gameObject);
            return instance;
        }

        public FruitController CreateFruit(FruitConfig fruitConfig, Transform parent)
        {
            var instance = Object.Instantiate(fruitConfig.fruitControllerPrefab, parent);
            _objectResolver.InjectGameObject(instance.gameObject);
            return instance;
        }

        public ObstacleController CreateObstacle(ObstacleController obstaclePrefab, Transform parent)
        {
           var instance = Object.Instantiate(obstaclePrefab, parent);
           _objectResolver.InjectGameObject(instance.gameObject);
           return instance;
        }
    }
}