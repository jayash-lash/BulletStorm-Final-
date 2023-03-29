using UnityEngine;

namespace Common.Movement
{
    public class DownwardMovement : BaseMovement
    {
        [SerializeField] private Vector3 _direction;
        // [SerializeField] private float _speedOfEnemy = 2f;

        public override void Move()
        {
            transform.position += _direction * (_speed * Time.deltaTime);
        }
    }
}