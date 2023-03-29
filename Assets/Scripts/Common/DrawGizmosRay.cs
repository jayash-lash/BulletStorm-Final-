using UnityEngine;

namespace Common
{
    public class DrawGizmosRay : MonoBehaviour
    {
        [Header("Raycast")]
        [SerializeField] private float _distance = 0.2f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawRay(position, gameObject.transform.up * _distance);
        }
    }
}