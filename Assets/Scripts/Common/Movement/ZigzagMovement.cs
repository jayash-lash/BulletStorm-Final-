using UnityEngine;
using Random = UnityEngine.Random;

namespace Common.Movement
{
    public class ZigzagMovement: BaseMovement
    {
        [SerializeField] private float _zigzagFrequency = 1f;
        [SerializeField] private Vector2 _minMaxAmplitude;
        [SerializeField] private Transform _transform;
        
        private float _initialXPosition;
        private float _amplitude;
        
        private void Awake()
        {
            _transform = transform;
            _initialXPosition = _transform.position.x;
            _amplitude = Random.Range(_minMaxAmplitude.x, _minMaxAmplitude.y);
        }
        public override void Move()
        {
            var currentPosition = _transform.position;
            currentPosition += Vector3.down * Time.deltaTime * _speed;
            currentPosition.x = _initialXPosition + Mathf.Sin(Time.time * _zigzagFrequency) * _amplitude;
            _transform.position = currentPosition;
        }
    }
}