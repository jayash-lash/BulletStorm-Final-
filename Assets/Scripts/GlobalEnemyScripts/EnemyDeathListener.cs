using System;
using Common;
using UnityEngine;

namespace Enemy
{
    public class EnemyDeathListener : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosionParticleSystem;
        [SerializeField] private Health _health;

        private Health Health => _health;
        
        private void Start()
        {
            Health.OnHealthZero += EnemyDied;
        }
        public void EnemyDied()
        {
            var newExplosion = Instantiate(_explosionParticleSystem, transform.position, Quaternion.identity); 
            if(newExplosion != null) newExplosion.Play();
        }

        private void OnDestroy()
        {
            Health.OnHealthZero += EnemyDied;
        }
    }

}