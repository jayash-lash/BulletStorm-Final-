using System;
using Common;
using Common.Movement;
using Enemy;
using FactoryElements.PowerUp;
using UnityEngine;
using Zenject;

namespace FactoryElements.Enemy
{
    public abstract class BaseEnemy : MonoBehaviour
    {
        [Inject] private IMovement _movement;
        
        public event Action<int> OnDeath;
        public event Action OnDeathCount;
        public event Action OnHealthZero
        {
            add => Health.OnHealthZero += value;
            remove=> Health.OnHealthZero -= value;

        }
        
        public Health Health => _health;
        public int Id => _collider.GetInstanceID();
        public int ScorePoints => _scorePoints;
        
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Health _health;
        [SerializeField] private PowerUpSpawner _powerUpSpawner;
        [SerializeField] protected int _scorePoints;
        
        private void Start()
        {
            Health.OnHealthZero += OnEnemyHealthZero; 
            Health.OnHealthZero += _powerUpSpawner.SpawnPowerUp;
        }
        
        private void Update()
        {
            _movement.Move();
        }
        
        private void OnEnemyHealthZero()
        {
            OnDeathCount?.Invoke();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            OnDeath?.Invoke(Id);
            OnDeathCount = null;
            if (Health != null)
            {
                Health.OnHealthZero += _powerUpSpawner.SpawnPowerUp;
                Health.OnHealthZero -= OnEnemyHealthZero;
            }
        }
    }
}