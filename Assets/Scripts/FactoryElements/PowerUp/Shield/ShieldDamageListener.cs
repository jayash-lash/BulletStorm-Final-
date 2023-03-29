using System;
using Common;
using Enemy;
using UnityEngine;
using Zenject;

namespace FactoryElements.PowerUp.Shield
{
    public class ShieldDamageListener : MonoBehaviour
    {
        private int Id => _collider.GetInstanceID();
        
        [Inject] private IEnemyManager _enemyManager;
        [SerializeField] private Health _shieldHealth;
        [SerializeField] private Collider2D _collider;

        [Header("Damage")] 
        [SerializeField] private int _shieldDamageToSomebody;
        [SerializeField] private int _damageOnShield;

        public void Start()
        {
            _shieldHealth.OnHealthZero += OnHealthZero;
        }

        private void OnHealthZero()
        {
            Destroy(gameObject);
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Trigger" + other.gameObject.name);
            
            if(_enemyManager.TryGetEnemiesHealth(other.GetInstanceID(), out var healthEnemy))
            {
                healthEnemy.TakeDamage(_shieldDamageToSomebody); 
                _shieldHealth.TakeDamage(_damageOnShield);
            }
        }

        public Health TryGetShieldHealth()
        {
            // if (Id == id)
            // {
            //     shieldHealth = _shieldHealth;
            //     return true;
            // }
            //
            // shieldHealth = null;
            return _shieldHealth;
        }
        
        private void OnDestroy()
        {
            _shieldHealth.OnHealthZero -= OnHealthZero;
        }
    }
}
 