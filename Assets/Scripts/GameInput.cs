using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _playerInputActions.Player.Enable();
    }
    
    // public Vector3 GEtMovement(float speed)
    // {
        
        // var yMovement = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        // var xMovement = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        // var inputVector = _transform.position;
        // inputVector += new Vector3(xMovement, yMovement);
        // inputVector = inputVector.normalized;

        // return inputVector;
    // }

    public Vector2 GetMovementVectorNormalized()
    {
        var inputVector = _playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;

        return inputVector;
    }
    
}
