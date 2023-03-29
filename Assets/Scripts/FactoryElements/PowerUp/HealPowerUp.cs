using UnityEngine;

namespace FactoryElements.PowerUp
{
    public class HealPowerUp : BasePowerUp
    {
        [SerializeField] private int _healAmount = 1;
        
        protected override void Apply(int colliderId)
        {
            _playersFacade.HealPlayer(_healAmount);
        }
    }
}