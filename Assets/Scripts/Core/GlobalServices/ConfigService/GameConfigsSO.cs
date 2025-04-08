using System.Collections.Generic;
using Core.GlobalServices.ConfigService.Config;
using Core.GlobalServices.CurtainService;
using Game.ChunkSystem;
using Game.Obstacle;
using Game.Player;
using Lobby.UI;
using UI;
using UnityEngine;

namespace Core.GlobalServices.ConfigService
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game Config", order = 0)]
    public sealed class GameConfigsSO : ScriptableObject
    {
        #region Prefabs

        [field: SerializeField] public LoadingCurtainView LoadingCurtainViewPrefab { get; private set; }
        [field: SerializeField] public List<ChunkController> ChunkControllersPrefabs { get; private set; }
        [field: SerializeField] public PlayerController PlayerControllerPrefab { get; private set; }
        [field: SerializeField] public List<ObstacleController> ObstacleControllersPrefab { get; private set; }
        
        [field: SerializeField] public BasePageView GameOverPagePrefab { get; private set; }
        [field: SerializeField] public BasePageView GamePagePrefab { get; private set; }
        [field: SerializeField] public BasePageView StartGamePagePrefab { get; private set; }
        [field: SerializeField] public BasePageView LobbyMainPageView { get; private set; }
        [field: SerializeField] public ScoreView ScoreViewPrefab { get; private set; }

        #endregion

        #region GameSettings

        [field: SerializeField] public Vector3 FirsChunkPosition { get; private set; }
        [field: SerializeField] public Vector3 PlayerPosition { get; private set; }
        [field: SerializeField] public int ChunksPerSpawn { get; private set; } = 10;
        [field: SerializeField] public int SpawnTriggerDistance { get; private set; } = 30;
            
        [field: SerializeField,Range(0f,1f)] public float FruitSpawnChance { get; private set; } = 0.3f;
        [field: SerializeField,Range(0f,1f)] public float ObstacleSpawnChance { get; private set; } = 0.45f;

        #endregion
        
        #region Configs
        
        [field: SerializeField] public List<FruitConfig> FruitConfigs { get; private set; }
        
        #endregion

        #region PlayerConfig

        [field: SerializeField] public float forwardSpeed { get; private set; } = 10;
        [field: SerializeField] public float laneSwitchSpeed { get; private set; } = 10;

        #endregion
    }
}