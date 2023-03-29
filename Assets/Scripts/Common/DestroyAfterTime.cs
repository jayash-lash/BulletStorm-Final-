using System;
using Common.Movement;
using UnityEngine;

namespace Common
{
    public class DestroyAfterTime : MonoBehaviour
    {
        public event Action OnDestroyed ;
        [SerializeField] private TimerOn _timer;
        [SerializeField] private float _lifetime;
        [SerializeField] private GameObject _gameObject;

        private void Awake()
        {
            if (_gameObject == null)
                _gameObject = gameObject;
            
            _timer.OnTimeIsOut += DestroyObject;
            _timer.StartTimer(_lifetime);

        }

        private void DestroyObject()
        {
            Destroy(_gameObject);
        }

        private void OnDestroy()
        {
            if (_timer != null)
                _timer.OnTimeIsOut -= DestroyObject;
            OnDestroyed?.Invoke(); 
        }
    }
}