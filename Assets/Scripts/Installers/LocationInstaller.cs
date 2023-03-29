using Enemy;
using FactoryElements.Enemy;
using FactoryElements.Enemy.EnemyBullet;
using FactoryElements.PowerUp;
using FactoryElements.PowerUp.Shield;
using Player;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [Header("Fabric")]
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private MissileFactory _missileFactory;
        [SerializeField] private PowerUpFactory _powerUpFactory;
        [SerializeField] private ShieldFabric _shieldFabric;
        [Header("Manager")]
        [SerializeField] private EnemyManager _enemyManager;
        [Header("Facade")] 
        [SerializeField] private PlayersFacade _playerFacade;
        
        public override void InstallBindings()
        {
            BindEnemyFactory();
            BindBulletFactory();
            BindPowerUpFactory();
            BindEnemyManager();
            BindPlayerFacade();
            BindShieldFactory();
            SignalBusInstaller.Install(Container);
        }

        private void BindPlayerFacade()
        {
            Container.
                Bind<PlayersFacade>().
                FromInstance(_playerFacade).
                AsSingle();
        }

        private void BindShieldFactory()
        {
            Container.
                Bind<ShieldFabric>().
                FromInstance(_shieldFabric).
                AsSingle();
        }

        private void BindPowerUpFactory()
        {
            Container.
                Bind<PowerUpFactory>().
                FromInstance(_powerUpFactory).
                AsSingle();
        }
        private void BindEnemyManager()
        {
            Container
                .BindInterfacesTo<EnemyManager>()
                .FromInstance(_enemyManager)
                .AsSingle();
        }
        private void BindBulletFactory()
        {
            Container.
                Bind<MissileFactory>().
                FromInstance(_missileFactory).
                AsSingle();
        }
        
        private void BindEnemyFactory()
        {
            Container.
                Bind<EnemyFactory>().
                FromInstance(_enemyFactory).
                AsSingle();
        }
    }
}