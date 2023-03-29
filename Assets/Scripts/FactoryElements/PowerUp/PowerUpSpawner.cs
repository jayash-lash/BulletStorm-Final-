using System;
using System.Collections.Generic;
using Common;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace FactoryElements.PowerUp
{
    public class PowerUpSpawner : MonoBehaviour
    {
        [Inject] private PowerUpFactory _powerUpFactory;
        public void SpawnPowerUp()
        {
            var position = transform.position;
            _powerUpFactory.CreateInstanceOfPowerUpToken(position);
        }
    }
}