using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace FactoryElements.PowerUp
{
    public class PowerUpFactory : MonoBehaviour
    {
        [Inject] private DiContainer _diContainer;
        [Header("Prefabs")] 
        [SerializeField] private BasePowerUp _healToken;
        [SerializeField] private BasePowerUp _shieldToken;

        [SerializeField, Range(0, 100)] private float _dropRate;
        [SerializeField] private List<ItemData> _items;
        private int _totalValue;

        private void Awake()
        {
            _totalValue = _items.Select(x => x._dropChance).Sum();
        }
        
        public void CreateInstanceOfPowerUpToken(Vector2 position)
        {
            DropChance(position);
        }


        private void DropChance(Vector2 position)
        {
            var dropValue = Random.Range(0, _totalValue);

            var random = Random.value;
            if (_dropRate / 100f >= random)
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    if (dropValue <= _items[i]._dropChance)
                    {
                        _diContainer.InstantiatePrefab(_items[i]._powerUpPrefab, position, Quaternion.identity, null);
                        break;
                    }

                    dropValue -= _items[i]._dropChance;
                }
            }
        }
        [Serializable]
        public class ItemData
        {
            public BasePowerUp _powerUpPrefab;
            public int _dropChance;
        }
    }
}