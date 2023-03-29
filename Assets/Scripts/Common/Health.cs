using System;
using UI;
using UnityEngine;

namespace Common
{
    public class Health : MonoBehaviour, IHealth
    {
        public event Action OnHealthZero;
        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;
        
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _id;
        [SerializeField] private HeartHealthBar _heartHealth;
        
        public void TakeDamage(int damage)
        {
            if (_currentHealth <= 0) return;
            _currentHealth -= Mathf.Abs(damage);
            if(_heartHealth != null)_heartHealth.TakeDamage(damage);
            if(_currentHealth <= 0) OnHealthZero?.Invoke();
        }
        
        public void Heal(int amount)
        {
            if (_currentHealth < _maxHealth)
            {
                _currentHealth += amount;
                _heartHealth.Heal(amount);
            }
            else _currentHealth = _maxHealth;
        }
    }

    public interface IHealth
    {
        public void TakeDamage(int damage);
        public void Heal(int amount);
    }
}