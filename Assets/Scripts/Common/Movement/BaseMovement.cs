using UnityEngine;

namespace Common.Movement
{
    public abstract class BaseMovement : MonoBehaviour, IMovement
    {
        public MovementType MovementType => _movementType;
        [SerializeField] protected float _speed;
        [SerializeField] private MovementType _movementType = MovementType.Null ;
        
        public abstract void Move();
    }
    
    public enum MovementType
    {
     Null = 0,
     
     Direct = 10,
     Circle,
     Zigzag
    }
}