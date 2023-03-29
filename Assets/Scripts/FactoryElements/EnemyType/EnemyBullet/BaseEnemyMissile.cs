using Enemy;
using FactoryElements.PowerUp.Shield;
using Player;
using UnityEngine;
using Zenject;
using Vector3 = UnityEngine.Vector3;

namespace FactoryElements.Enemy.EnemyBullet
{
    public abstract class BaseEnemyMissile : MonoBehaviour
    {
        [Inject] protected PlayersFacade _playerFacade;
        [Inject] protected MissileFactory _missileFactory;
        
        [Header("SettingProperties")]
        [SerializeField] protected float _speed;
        [SerializeField] protected int _damage;
        [SerializeField] protected LayerMask _ignoreLayers;
        [Header("Raycast")]
        [SerializeField] protected float _distance = 0.2f;

        protected float _elapsedTime;
        protected RaycastHit2D _hit;
        
        
        
        protected Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
            MovementDirection();
            MissileDamage();
        }

        protected abstract void MovementDirection();

        private void MissileDamage()
        {
            _hit = Physics2D.Raycast(_transform.position, gameObject.transform.up, _distance);//, ~_ignoreLayers);
        
            if (_hit.collider == null) return;

            var shieldDamage = _hit.collider.GetComponent<ShieldDamageListener>();
            
            if(shieldDamage != null)
            {
                shieldDamage.TryGetShieldHealth().TakeDamage(_damage);
                Destroy(gameObject);
                return;
            }
            
            if(_playerFacade.TryGetPlayerHealth(_hit.collider.GetInstanceID(), out var playerHealth))
            {
                playerHealth.TakeDamage(_damage);
                Destroy(gameObject);
            }
            
          
        }

        private void OnBecameInvisible() => Destroy(gameObject);
    }
}
