using Common;
using Common.Movement;
using UI;
using UnityEngine;
using Zenject;

namespace Enemy
{
    public abstract class BaseEnemySpawnerStrategy : MonoBehaviour
    {
        [Inject] protected EnemyFactory _enemyFactory;
        [SerializeField] protected Transform[] _spawnPoints;
        [SerializeField] protected TimerOn _timer;
        
        [Header("Time")]
        [SerializeField] protected float _timeBetweenSpawn;
        [SerializeField] protected UIScore _ui;
        [field: SerializeField] public float SpawnDelay { get; private set; }

        public abstract void Spawn();
    }
}