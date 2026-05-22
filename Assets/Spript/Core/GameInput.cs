using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerAction _playerInputActions;
    private void Awake()
    {
        _playerInputActions = new PlayerAction();
        _playerInputActions.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized()
    {
        Vector2 inputDirction = _playerInputActions.Player.Move.ReadValue<Vector2>();
        inputDirction = inputDirction.normalized;
        return inputDirction;
    }
}
