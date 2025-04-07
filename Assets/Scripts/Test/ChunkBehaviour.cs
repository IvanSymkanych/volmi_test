using UnityEngine;

namespace Test
{
    public class ChunkBehaviour : MonoBehaviour
    {
        [field:SerializeField] public Transform StartPoint { get; private set; }
        [field:SerializeField] public Transform EndPoint { get; private set; }
    }
}