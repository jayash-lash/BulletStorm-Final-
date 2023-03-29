using System;
using UnityEngine;

namespace Common
{
    public class SceneBounds : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _backGround;
        [SerializeField] private SpriteRenderer _rendererPlayer;
        
        [SerializeField] private Transform _player;
        [SerializeField] private Vector2 _sizePlayerOffset;

        [SerializeField] private bool _draw = true;
        [SerializeField] private Color _colorDraw = Color.red;

        // private Vector2 _sizePlayer;
        private Vector3 _leftDownPosition;
        private Vector3 _rightUpPoint;

        private void Start()
        {
            var sizeBg = _backGround.size * 0.5f * _backGround.transform.lossyScale;
            // _sizePlayer = _rendererPlayer.size * 0.5f * _rendererPlayer.transform.lossyScale;
            _leftDownPosition = new Vector3(-sizeBg.x + _sizePlayerOffset.x, -sizeBg.y + _sizePlayerOffset.y, 0);
            _rightUpPoint = new Vector3(sizeBg.x - _sizePlayerOffset.x, sizeBg.y - _sizePlayerOffset.y, 0);
        }

        public void SetPlayerPosition(Vector3 position)
        {
            var xPos = Mathf.Clamp(position.x, _leftDownPosition.x, _rightUpPoint.x);
            var yPos = Mathf.Clamp(position.y, _leftDownPosition.y, _rightUpPoint.y);

            _player.position = new Vector3(xPos, yPos, position.z);
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (!_draw) return;

            if (_backGround == null || _rendererPlayer == null)
            {
                _draw = false;
                return;
            }

            var sizeBg = _backGround.size * 0.5f * _backGround.transform.lossyScale;
            var sizePlayer = _sizePlayerOffset;

            var leftDown = new Vector3(-sizeBg.x + sizePlayer.x, -sizeBg.y + sizePlayer.y, 0);
            var leftUp = new Vector3(-sizeBg.x + sizePlayer.x, sizeBg.y - sizePlayer.y, 0);
            var rightUp = new Vector3(sizeBg.x - sizePlayer.x, sizeBg.y - sizePlayer.y, 0);
            var rightDown = new Vector3(sizeBg.x - sizePlayer.x, -sizeBg.y + sizePlayer.y, 0);

            Gizmos.color = _colorDraw;
            
            Gizmos.DrawLine(leftDown, leftUp);
            Gizmos.DrawLine(leftUp, rightUp);
            Gizmos.DrawLine(rightUp, rightDown);
            Gizmos.DrawLine(leftDown, rightDown);
        }
#endif
    }
}