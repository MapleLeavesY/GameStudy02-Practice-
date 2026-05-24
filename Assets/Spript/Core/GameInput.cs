using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    private PlayerAction _playerInputActions;
    private void Awake()
    {
        _playerInputActions = new PlayerAction();
        _playerInputActions.Player.Enable(); 
        
        _playerInputActions.Player.Interact.performed += Interact_performed;
    }
    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log(obj);
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputDirction = _playerInputActions.Player.Move.ReadValue<Vector2>();
        inputDirction = inputDirction.normalized;
        return inputDirction;
    }
}
