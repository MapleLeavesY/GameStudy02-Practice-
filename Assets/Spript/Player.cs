using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private GameInput _gameInput;
    private bool _isWalking;
    
    private void Update()
    {
        Vector2 inputDirction = _gameInput.GetMovementVectorNormalized();
        Vector3 changeDirction = new Vector3(inputDirction.x, 0, inputDirction.y);

        transform.forward = Vector3.Slerp
        (//玩家朝向球形旋转
            transform.forward,
            changeDirction,
            _rotationSpeed * Time.deltaTime
        );
        transform.position += changeDirction * _moveSpeed * Time.deltaTime;
        _isWalking = changeDirction != Vector3.zero;
    }
    public bool IsWalking()
    {
        return _isWalking;
    }
}
