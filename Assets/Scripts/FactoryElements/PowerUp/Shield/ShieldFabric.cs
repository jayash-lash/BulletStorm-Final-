using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace FactoryElements.PowerUp.Shield
{
    public class ShieldFabric : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;
        [SerializeField] private GameObject _playerShield;

        public void CreateOnSomebody(Vector2 position, Transform parent)
        {
            _diContainer.
                InstantiatePrefab(_playerShield, position, Quaternion.identity, parent);
        }
    }
}