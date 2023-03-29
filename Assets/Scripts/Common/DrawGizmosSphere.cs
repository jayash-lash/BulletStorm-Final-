using UnityEngine;

namespace Common
{
    public class DrawGizmosSphere : MonoBehaviour
    {
        [SerializeField] private float _radius = 0.2f;
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}