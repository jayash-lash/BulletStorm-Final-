using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class SpawnSingleEnemyStrategy : BaseEnemySpawnerStrategy
    {

        public override void Spawn()
        {
            var posLeftPoint = _spawnPoints[0].position;
            var posRightPoint = _spawnPoints[_spawnPoints.Length - 1].position;
            
            var spawnPosition = Vector3.zero;
            spawnPosition.y = posLeftPoint.y;
            spawnPosition.x = Random.Range(posLeftPoint.x, posRightPoint.x);
            
            // var spawnPoint = Random.Range(0,_spawnPoints.Length);
            // var point = _spawnPoints[spawnPoint].position;
            var enemy = _enemyFactory.CreateByRandom(spawnPosition);
            
            // UI Event
            enemy.OnHealthZero += () => _ui.IncreaseScore(enemy.ScorePoints);

            _timer.StartTimer(_timeBetweenSpawn);
        }
    }
}