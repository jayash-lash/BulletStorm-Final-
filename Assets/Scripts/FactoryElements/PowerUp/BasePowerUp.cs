using Player;
using UnityEngine;
using Zenject;

namespace FactoryElements.PowerUp
{
    public abstract class BasePowerUp : MonoBehaviour
    {
        [Inject] protected PlayersFacade _playersFacade;
        
        private void OnTriggerEnter2D(Collider2D collider2D)
        {
            var id = collider2D.GetInstanceID();
            Apply(id);
            Destroy(gameObject);
        }

        protected abstract void Apply(int colliderId);
    }
}