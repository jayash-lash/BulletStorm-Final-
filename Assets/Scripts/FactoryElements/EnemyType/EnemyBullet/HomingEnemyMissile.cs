using UnityEngine;
using Zenject;

namespace FactoryElements.Enemy.EnemyBullet
{
    public class HomingEnemyMissile : BaseEnemyMissile
    {
        [Inject] private Transform _playerTransform;

        [SerializeField, Range(0.5f, 30)] private float _speedRotation = 0.1f;
        [SerializeField] private float _stopFollowDistance = 3f;
        
        private bool _isClosesToPlayer;
        
        protected override void MovementDirection()
        {
            if (!_isClosesToPlayer)
            {
                var distanceToPlayer = Vector3.Distance(transform.position, _playerTransform.position);

                var pos = _playerTransform.position - transform.position;
                var currentRotation = transform.rotation;
                var rotation = Quaternion.LookRotation(Vector3.forward, pos.normalized);
                
                transform.rotation = Quaternion.Lerp(currentRotation, rotation, _speedRotation * Time.deltaTime);
                _isClosesToPlayer = distanceToPlayer <= _stopFollowDistance;
            }
            
            var nextPosition = transform.position + (transform.up  * _speed * Time.deltaTime);
            
           if(_playerTransform != null) transform.position = nextPosition;
        }
    }
}