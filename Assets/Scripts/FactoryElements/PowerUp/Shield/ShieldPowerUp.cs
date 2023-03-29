using Zenject;

namespace FactoryElements.PowerUp.Shield
{
    public class ShieldPowerUp : BasePowerUp
    {
        [Inject] private ShieldFabric _shieldFabric;

        protected override void Apply(int colliderId)
        {
            var transform1 = _playersFacade.transform;
            _shieldFabric.CreateOnSomebody(transform1.position, transform1);
        }
    }
}