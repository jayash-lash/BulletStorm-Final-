using System;
using Common;
using UnityEngine;
using UnityEngine.Rendering;

namespace Player
{
    public class PlayersFacade : MonoBehaviour
    {
       
        private int Id => _collider.GetInstanceID();
        [SerializeField] private Health _playerHealth;
        [SerializeField] private PlayerDamageBySmthListener _playerDamageBySmth;
        [SerializeField] private GameObject _missileSpawner;
        [SerializeField] private Collider2D _collider;
        
        public void HealPlayer(int amount)
        {
            _playerHealth.Heal(amount);
        }
        
        public bool TryGetPlayerHealth(int id, out Health playerHealth)
        {
            if (Id == id)
            {
                playerHealth = _playerHealth;
                return true;
            }

            playerHealth = null;
            return false;
        }
    }
}