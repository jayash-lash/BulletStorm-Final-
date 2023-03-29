using Enemy;
using UnityEngine;

namespace FactoryElements.PlayersBullet
{
    public class HomingMissile : BaseMissile
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        
        [Header("Raycast")]
        [SerializeField] private float _distance = 0.2f;
        
        [SerializeField] private LayerMask _ignoreLayers;
        
        private RaycastHit2D _hit;
        private bool _enemyTargetFound;
        private Vector3 _direction = Vector3.up;

        protected override void MovementDirection()
        {
            var enemyList = _enemyManager.TryGetClosestEnemy(gameObject.transform.position, out var enemyArgs);
            if (enemyList)
            {
                HomingMissileMovement(enemyArgs);
            }
            else _transform.position += _direction * _speed * Time.deltaTime;
        }

        protected override void MissileDamage()
        {
            _hit = Physics2D.Raycast(_transform.position,gameObject.transform.up, _distance, ~_ignoreLayers);
        
            if (_hit.collider == null) return;
            
            if(_enemyManager.TryGetEnemiesHealth(_hit.collider.GetInstanceID(), out var healthEnemy))
            {
                healthEnemy.TakeDamage(_damage); 
                Destroy(gameObject);
            }
        }

        private void HomingMissileMovement(EnemyArgs enemyArgs)
        {
            if (enemyArgs.Enemy == null)
            { 
                Destroy(gameObject);
                return;
            }

            var position = _transform.position;
            Vector3 direction = position - enemyArgs.TransformEnemy.transform.position;

            //normalize direction to set the maximum length of the magnitude to 1. 
            _direction = -direction.normalized;
    
            // set the front (nose) of the missile to face towards the enemy target.
            _transform.rotation = Quaternion.LookRotation(_transform.forward, _direction);
    
            //move in the direction specified at the missile’s speed in real time.
            position += _direction * _speed * Time.deltaTime;
            _transform.position = position;
        }
    }
}