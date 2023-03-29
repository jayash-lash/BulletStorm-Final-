using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HeartView : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Color _activeColor;
        [SerializeField] private Color _inactiveColor;
        [SerializeField] private float _animationDuration;

        private Tween _currentAnimation;
        private bool _isActive = false;

        [ContextMenu(nameof(Enable))] public void Enable()
        {
            SetActive(true);
        }
        

        [ContextMenu(nameof(Disable))] public void Disable()
        {
            SetActive(false);
        }

        public void SetActive(bool isActive)
        {
            _currentAnimation?.Kill();

            if (isActive && !_isActive)
            {
                // turn on
                _currentAnimation = _image.DOColor(_activeColor, _animationDuration).OnComplete(() => _isActive = true);
                
                // _currentAnimation = DOVirtual.Float(0, 1, _animationDuration, progress =>
                // {
                    // Color.RGBToHSV(_image.color, out var hCur, out var sCur, out var vCur);
                    // Color.RGBToHSV(_activeColor, out var hNext, out var sNext, out var vNext);

                    // var sNew = Mathf.Lerp(sCur, sNext, progress);
                    // var hNew = Mathf.Lerp(hCur, hNext, progress);
                    // var vNew = Mathf.Lerp(vCur, vNext, progress);

                    // _image.color = Color.HSVToRGB(hNew, sNew, vNew);
                // }).OnComplete(() => _isActive = true);
            }
            else if (!isActive && _isActive)
            {
                // turn off
                _currentAnimation = _image.DOColor(_inactiveColor, _animationDuration).OnComplete(() => _isActive = false);

                // _currentAnimation = DOVirtual.Float(0, 1, _animationDuration, progress =>
                // {
                //     Color.RGBToHSV(_image.color, out var hCur, out var sCur, out var vCur);
                //     Color.RGBToHSV(_inactiveColor, out var hNext, out var sNext, out var vNext);
                //
                //     var sNew = Mathf.Lerp(sCur, sNext, progress);
                //     var hNew = Mathf.Lerp(hCur, hNext, progress);
                //     var vNew = Mathf.Lerp(vCur, vNext, progress);
                //
                //     _image.color = Color.HSVToRGB(hNew, sNew, vNew);
                // }).OnComplete(() => _isActive = false);
            }
        }

        private void OnDestroy()
        {
            _currentAnimation?.Kill();
        }
    }
}