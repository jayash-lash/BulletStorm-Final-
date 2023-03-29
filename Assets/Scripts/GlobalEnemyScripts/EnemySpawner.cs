using System.Collections.Generic;
using Common;
using Common.Movement;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [Header("Time")]
        [SerializeField] private TimerOn _timer;
        [SerializeField] private float _initialSpawnDelay = 2f;

        [SerializeField] private List<BaseEnemySpawnerStrategy> _strategyOfSpawn = new List<BaseEnemySpawnerStrategy>();

        private void Awake()
        {
            _timer.OnTimeIsOut += ChooseSpawningMethod;
            _timer.StartTimer(_initialSpawnDelay);
        }

        private void ChooseSpawningMethod()
        {
            var index = Random.Range(0, _strategyOfSpawn.Count);
            var concreteStrategy = _strategyOfSpawn[index];
            concreteStrategy.Spawn();

            var delay = concreteStrategy.SpawnDelay;
            _timer.StartTimer(delay);
        }

        private void OnDestroy()
        {
            if (_timer != null)
                _timer.OnTimeIsOut -= ChooseSpawningMethod;
        }
    }
}