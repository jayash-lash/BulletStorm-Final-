using UnityEngine;

namespace FactoryElements.PlayersBullet
{
    public class OrdinaryMissile : BaseMissile
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage;
        
        [Header("Raycast")]
        [SerializeField] private float _distance = 0.2f;
        
        [SerializeField] private LayerMask _ignoreLayers;
        
        private RaycastHit2D _hit;

        protected override void MovementDirection()
        {
            _transform.position += Vector3.up * (_speed * Time.deltaTime);
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
    }
}