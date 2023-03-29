 using Common;
 using UnityEngine;

namespace Player
{
    
    //Refactor this whole code to new input system
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float _speed = 6.6f;
        [SerializeField] private GameInput _gameInput;
        [SerializeField] private SceneBounds _scene;
        
        private Transform _transform;

        private void Awake()
        {
            _transform = transform;
        }

        private void Update()
        {
           var inputVector =  _gameInput.GetMovementVectorNormalized();
           _scene.SetPlayerPosition(_transform.position + (Vector3)inputVector * _speed * Time.deltaTime);
        }
    }
}
