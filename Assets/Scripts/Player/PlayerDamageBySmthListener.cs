using Common;
using Enemy;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerDamageBySmthListener : MonoBehaviour
    {
        [Inject] private IEnemyManager _enemyManager;
        [SerializeField] private Health _playerHealth;
        [SerializeField] private ParticleSystem _playerExplosion;

        [Header("Damage")] 
        [SerializeField] private int _playerDamageToSomebody;
        [SerializeField] private int _damageOnPlayer;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Trigger" + other.gameObject.name);
            
            if(_enemyManager.TryGetEnemiesHealth(other.GetInstanceID(), out var healthEnemy))
            {
                healthEnemy.TakeDamage(_playerDamageToSomebody); 
                _playerHealth.TakeDamage(_damageOnPlayer);
            }

            if (_playerHealth.CurrentHealth <= 0)
            {
                PlayerDies();
            }
        }

        public void PlayerDies()
        {
            var newExplosion = Instantiate(_playerExplosion, transform.position, Quaternion.identity); 
            if(newExplosion != null) newExplosion.Play();
            Destroy(gameObject);
        }
    }
}