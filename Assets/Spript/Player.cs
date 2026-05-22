using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 10f; 
    [SerializeField] private GameInput _gameInput;
    private bool _isWalking;
    
    private void Update()
    {       
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking()
    {
        return _isWalking;
    }
    private void HandleInteractions()
    {
        Vector2 inputDirction = _gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3
        (
            inputDirction.x, 
            0f, 
            inputDirction.y
        );
        float interactDistance = 2f;
        if(Physics.Raycast(transform.position, moveDir, out RaycastHit raycastHit, interactDistance))
        {
            Debug.Log(raycastHit.transform.position);
        }
    }
    private void HandleMovement()
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
            
            Vector3 moveDirX = new Vector3
            (//尝试在X方向移动
                moveDir.x,
                0f,
                0f
            ).normalized;
            canMove = !Physics.CapsuleCast
            (
                transform.position,
                transform.position + Vector3.up * playerHeight,
                _playerRadius,
                moveDirX,
                moveDistance
            );
            if(canMove)
            {//如果可以移动，那么更换移动方向
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3
                (//尝试在Z方向移动
                    0f,
                    0f,
                    moveDir.z
                ).normalized;
                canMove = !Physics.CapsuleCast
                (
                    transform.position,
                    transform.position + Vector3.up * playerHeight,
                    _playerRadius,
                    moveDirZ,
                    moveDistance
                );
                if(canMove)
                {//如果可以移动，那么更换移动方向
                    moveDir = moveDirZ;
                }
            }
        }
        if(canMove)
        {//可以朝着这个方向移动
            transform.position += moveDir * moveDistance;
        }
    }
}
