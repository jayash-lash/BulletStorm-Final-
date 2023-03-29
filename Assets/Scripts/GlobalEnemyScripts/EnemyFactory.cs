using FactoryElements.Enemy;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;
        [Inject] private IEnemyRegistry _enemyRegistry;
    
        [SerializeField] private BaseEnemy[] _enemyPrefabs;
    
        public BaseEnemy CreateByRandom(Vector2 position)
        {
            var random = Random.Range(0, _enemyPrefabs.Length);
            var prefab = _enemyPrefabs[random];
            BaseEnemy enemy = null;
        
            enemy = _diContainer.InstantiatePrefabForComponent<BaseEnemy>(prefab, position, Quaternion.identity, null);
            // enemy = Instantiate(prefab, position, Quaternion.identity, null);
        
            var enemyArgs = new EnemyArgs(enemy.transform, enemy);
            _enemyRegistry.AddEnemy(enemyArgs);

            return enemy;
        }
    }
}