using UnityEngine;

namespace Helpers
{
    public class GizmoSphereDrawer : MonoBehaviour
    {
        [SerializeField] private float radius = 0.2f;
        [SerializeField] private Color color = Color.yellow;

        private void OnDrawGizmos()
        {
            Gizmos.color = color;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}