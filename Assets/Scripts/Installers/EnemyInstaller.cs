using System.Collections.Generic;
using Common.Movement;
using FactoryElements.Enemy.EnemyBullet;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private List<BaseMovement> _enemyMovement = new List<BaseMovement>();

        public override void InstallBindings()
        {
            var indexMove = Random.Range(0, _enemyMovement.Count);
            var concreteMovementStrategy = _enemyMovement[indexMove];
            var missileType = GetMissileType(concreteMovementStrategy);
            
            Container.Bind<IMovement>().FromInstance(concreteMovementStrategy).AsSingle().NonLazy();
            Container.Bind<EnemyMissileType>().FromInstance(missileType).AsSingle();
        }

        private EnemyMissileType GetMissileType(BaseMovement movement)
        {
            switch (movement.MovementType)
            {
                case MovementType.Zigzag:
                    return EnemyMissileType.Homing;
                case MovementType.Direct:
                    return EnemyMissileType.Null;
                default:
                    return EnemyMissileType.Direct;
            }
        }
    }
}