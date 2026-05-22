using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 10f;
    [SerializeField] private GameInput _gameInput;
    private bool _isWalking;
    
    private void Update()
    {
        Vector2 inputDirction = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3
        (
            inputDirction.x, 
            0f, 
            inputDirction.y
        );

        float playerHeight = 2f;
        float _playerRadius = .7f;
        float moveDistance = _moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast
        (
            transform.position,
            transform.position + Vector3.up * playerHeight,
            _playerRadius,
            moveDir,
            moveDistance
        );
        _isWalking = moveDir != Vector3.zero;
        transform.forward = Vector3.Slerp
        (
            transform.forward,
            moveDir,
            Time.deltaTime * _rotateSpeed 
        );
        if(!canMove)
        {//不能朝着这个方向移动
            
        }
        if(canMove)
        {//可以朝着这个方向移动
            transform.position += moveDir * moveDistance;
        }
    }
    public bool IsWalking()
    {
        return _isWalking;
    }
}
