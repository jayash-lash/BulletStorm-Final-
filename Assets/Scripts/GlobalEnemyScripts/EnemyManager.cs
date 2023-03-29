using System.Collections.Generic;
using Common;
using FactoryElements.Enemy;
using UnityEngine;

namespace Enemy
{
    public class EnemyManager : MonoBehaviour, IEnemyManager, IEnemyRegistry
    {
        private List<EnemyArgs> _enemyMap = new List<EnemyArgs>();

        public void AddEnemy(EnemyArgs enemy)
        {
            if (_enemyMap.Contains(enemy)) return;
            _enemyMap.Add(enemy);

            enemy.Enemy.OnDeath += RemoveEnemy;
        }

        public void RemoveEnemy(int id)
        {
            foreach (var enemy in _enemyMap)
            {
                if (enemy.Enemy.Id == id)
                {
                    enemy.Enemy.OnDeath -= RemoveEnemy;
                    _enemyMap.Remove(enemy);
                    break;
                }
            }
        }

        public bool TryGetClosestEnemy(Vector3 position, out EnemyArgs enemyArgs)
        {
            var distance = float.MaxValue;
            enemyArgs = null;
            
            foreach (var enemy in _enemyMap)
            {
                var distanceToEnemy = Vector3.Distance(enemy.TransformEnemy.position, position);
                if (distance > distanceToEnemy)
                {
                    distance = distanceToEnemy;
                    enemyArgs = enemy;
                }
            }

            return enemyArgs != null; //!ReferenceEquals(enemyArgs, null);
        }

        public bool TryGetEnemiesHealth(int id, out Health healthEnemy)
        {
            foreach (var enemy in _enemyMap)
            {
                if (enemy.Enemy.Id == id)
                {
                    healthEnemy = enemy.Enemy.Health;
                    return true;
                }
            }
            healthEnemy = null;
            return false;
        }
    }

    public interface IEnemyManager
    { 
        bool TryGetClosestEnemy(Vector3 position, out EnemyArgs enemyArgs);
        bool TryGetEnemiesHealth(int id, out Health healthEnemy);
    }

    public interface IEnemyRegistry
    {
        void AddEnemy(EnemyArgs enemy);
        void RemoveEnemy(int id);
    }

    public class EnemyArgs
    {
        public readonly Transform TransformEnemy;
        public readonly BaseEnemy Enemy;

        public EnemyArgs(Transform transformEnemy, BaseEnemy enemy)
        {
            TransformEnemy = transformEnemy;
            Enemy = enemy;
        }
    }
}