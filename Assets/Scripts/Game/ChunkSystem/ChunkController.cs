using System.Collections.Generic;
using UnityEngine;

namespace Game.ChunkSystem
{
    public class ChunkController : MonoBehaviour
    {
        [field:SerializeField] public Transform StartPoint { get; private set; }
        [field:SerializeField] public Transform EndPoint { get; private set; }
        [field:SerializeField] public List<Transform> FruitsSpawnPoints { get; private set; }
        [field:SerializeField] public List<Transform> ObstacleSpawnPoints { get; private set; }

        public void Initialize()
        {
        }

        public void Dispose()
        {
            Destroy(gameObject);
        }
    }
}