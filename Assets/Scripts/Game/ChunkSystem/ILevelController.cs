using UnityEngine;

namespace Game.ChunkSystem
{
    public interface ILevelController
    {
        void Initialize(Transform playTransform);
        void StartGame();
        void GameOver();
    }
}