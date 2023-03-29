using Common;
using Common.Movement;
using UnityEngine;
using Zenject;

namespace FactoryElements.Enemy.EnemyBullet
{
    // public abstract class EnemyMissileSpawnerBase : MonoBehaviour
    // {
    //     [Inject] protected MissileFactory _missileFactory;
    //     
    //     [SerializeField] private TimerOn _timer;
    //     
    //     [Header("Time(Enemy)")] 
    //     [SerializeField] private float _initialDelay = 2f;
    //     [SerializeField] protected float _timeBetweenSpawnMissile;
    //     
    //     private float _elapsedTime;
    //     
    //     private void Awake()
    //     {
    //         _timer.OnTimeIsOut += SpawnEnemyMissile;
    //                 
    //         _timer.StartTimer(_initialDelay);
    //     }
    //
    //     protected abstract void SpawnEnemyMissile();
    // }

    public class EnemyMissileSpawner : MonoBehaviour
    {
        [Inject] private MissileFactory _missileFactory;
        [Inject] private EnemyMissileType _missileType;

        [SerializeField] private TimerOn _timer;

        [Header("Time(Enemy)")] [SerializeField]
        private float _initialDelay = 2f;

        [SerializeField] private float _timeBetweenSpawnMissile;

        private float _elapsedTime;

        private void Awake()
        {
            _timer.OnTimeIsOut += SpawnEnemyMissile;

            _timer.StartTimer(_initialDelay);
        }


        private void SpawnEnemyMissile()
        {
            // if(_baseMovements[0]) SpawnEnemyMissileOn();
            // else if (_baseMovements[1]) SpawnEnemyMissileOn();
            // else if (_baseMovements[2]) SpawnEnemyMissileOff();

            // _elapsedTime += Time.deltaTime;
            // var isTimePassed = _elapsedTime > _timeBetweenSpawnMissile;
            //
            // if (!isTimePassed) return;
            // _elapsedTime = 0;

            _missileFactory.CreateInOnePositionOfEnemy(transform.position, _missileType);
        }

        // private void SpawnEnemyMissileOff()
        // {
        //     
        // }
        //
        // private void SpawnEnemyMissileOn()
        // {
        //     _elapsedTime += Time.deltaTime;
        //     var isTimePassed = _elapsedTime > _timeBetweenSpawnMissile;
        //
        //     if (!isTimePassed) return;
        //     _elapsedTime = 0;
        //
        //     _missileFactory.CreateInOnePositionOfEnemy(transform.position, _missileType);
        // }
    }
}