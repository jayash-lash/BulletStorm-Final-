using System;
using DG.Tweening;
using UnityEngine;

namespace Common
{
    
    public class TimerOn : MonoBehaviour
    {
        public event Action OnTimeIsOut;
        public bool IsTimerActive => _timer != null && _timer.IsPlaying();
        
        [SerializeField] private float _delayDefault = 5f;
        private Tween _timer;

        public void StartTimer(float delayOverride = -1)
        {
            if (IsTimerActive) StopTimer();
            
            if (delayOverride < 0) delayOverride = _delayDefault;
            _timer = DOVirtual.DelayedCall(delayOverride, () =>
            {
                _timer = null;
                OnTimeIsOut?.Invoke();
            });
        }

        public void StopTimer(bool withCallback = false) => _timer?.Complete(withCallback);

        private void OnDisable() => _timer?.Kill();
    }
}