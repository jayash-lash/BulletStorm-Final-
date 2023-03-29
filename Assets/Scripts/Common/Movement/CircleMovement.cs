using UnityEngine;
using Zenject;

namespace Common.Movement
{
    public class CircleMovement : BaseMovement
    {
        [Inject] protected Transform _player;
        
        // [SerializeField] private float _speed = 3f;
        
        [SerializeField] private float _radius = 1.5f;
        [SerializeField] private float _angle = 10f;
        [SerializeField] private Transform _centerPoint;
        
        [SerializeField] private Transform _transform;
        private Vector3 _originalPosition;
        private void Awake()
        {
            _transform = transform;
            _originalPosition = _transform.position;

            _angle = Mathf.Atan2(_player.position.y - _originalPosition.y, _player.position.x - _originalPosition.x);
            
            _centerPoint = new GameObject("CenterPoint").transform;
            _centerPoint.position = transform.position + new Vector3(0.1f, 0f, 0f);
        }
        
        public override void Move()
        {
            _originalPosition += Vector3.down * _speed * Time.deltaTime;
            
            _angle += _speed * Time.deltaTime;
            float x = Mathf.Cos(_angle) * _radius;
            float y = Mathf.Sin(_angle) * _radius;

            Vector3 newPosition = new Vector3(x, y, _transform.position.z);

            _transform.position = newPosition + _originalPosition;
        }
        private void OnDestroy()
        {
            if (_centerPoint != null && _transform != null) Destroy(_centerPoint.gameObject);
        }

    
    }
}