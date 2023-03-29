using Enemy;
using UnityEngine;
using Zenject;

namespace FactoryElements.PlayersBullet
{
    public abstract class BaseMissile : MonoBehaviour
    {
        [Inject] protected IEnemyManager _enemyManager;
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
        protected abstract void MissileDamage();
        private void OnBecameInvisible() => Destroy(gameObject);
    }
}