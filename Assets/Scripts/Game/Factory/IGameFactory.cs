using Core.GlobalServices.ConfigService.Config;
using Game.ChunkSystem;
using Game.Collectable;
using Game.Obstacle;
using Game.Player;
using UnityEngine;

namespace Game.Factory
{
    public interface IGameFactory
    {
        PlayerController CreatePlayer();
        ChunkController CreateChunk(ChunkController chunkPrefab);
        FruitController CreateFruit(FruitConfig fruitConfig, Transform parent);
        ObstacleController CreateObstacle(ObstacleController obstaclePrefab, Transform parent);
    }
}