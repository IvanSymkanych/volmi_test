using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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

        private void SpawnNextChunk()
        {
            var prefab = chunkPrefabs[Random.Range(0, chunkPrefabs.Count)];
            var chunk = Instantiate(prefab, spawnRoot);

            if (chunk.StartPoint == null || chunk.EndPoint == null)
            {
                Debug.LogError($"Chunk {chunk.name} is missing StartPoint or EndPoint!");
                Destroy(chunk.gameObject);
                return;
            }

            if (_lastChunk == null)
            {
                var offset = chunk.transform.position - chunk.StartPoint.position;
                chunk.transform.position = Vector3.zero + offset;
            }
            else
            {
                var offset = chunk.transform.position - chunk.StartPoint.position;
                chunk.transform.position = _lastChunk.EndPoint.position + offset;
            }

            _lastChunk = chunk;
        }
    }
}