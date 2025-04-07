using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// Підключаємо простір імен для ChunkBehaviour

namespace Test
{
    public class ChunkSpawner : MonoBehaviour
    {
        [SerializeField] private List<ChunkBehaviour> chunkPrefabs;
        [SerializeField] private Transform spawnRoot;

        private ChunkBehaviour _lastChunk;

        private void Start()
        {
            for (int i = 0; i < 10; i++)
            {
                SpawnNextChunk();
            }
        }

        public void SpawnNextChunk()
        {
            var prefab = chunkPrefabs[0];
            var newChunk = Instantiate(prefab, spawnRoot);

            if (newChunk.StartPoint == null || newChunk.EndPoint == null)
            {
                Debug.LogError($"Chunk {newChunk.name} is missing StartPoint or EndPoint!");
                Destroy(newChunk.gameObject);
                return;
            }

            if (_lastChunk == null)
            {
                // Перший чанк — ставимо його так, щоб StartPoint = Vector3.zero
                Vector3 offset = newChunk.transform.position - newChunk.StartPoint.position;
                newChunk.transform.position = Vector3.zero + offset;
            }
            else
            {
                // Вирівнюємо StartPoint нового чанка до EndPoint попереднього
                Vector3 offset = newChunk.transform.position - newChunk.StartPoint.position;
                newChunk.transform.position = _lastChunk.EndPoint.position + offset;
            }

            _lastChunk = newChunk;
        }

        public void ResetSpawner()
        {
            _lastChunk = null;
        }
    }
}