using UnityEngine;

namespace Enemy
{
    public class SpawnMultipleEnemyStrategy : BaseEnemySpawnerStrategy
    {
        // [SerializeField, Min(1)] private int _maxCountEnemy = 6;
        public override void Spawn()
        {
            var index = Random.Range(0,_spawnPoints.Length);
        
            for (int i = 0; i < index; i++)
            {
                var spawnPoint = Random.Range(0,_spawnPoints.Length);
                var point = _spawnPoints[spawnPoint].position;
            
                var enemy = _enemyFactory.CreateByRandom(point);
                enemy.OnHealthZero += () => _ui.IncreaseScore(enemy.ScorePoints);
            }
        
            _timer.StartTimer(_timeBetweenSpawn);
        }
    }
}