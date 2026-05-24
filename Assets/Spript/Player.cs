using System;
using UnityEngine;

public class Player : MonoBehaviour
{   

    public static Player Instance
    {
        private set;
        get;
    }

    public event EventHandler<OnSelectedCountChangeedEventArgs> OnSelectedCountChangeed;
    public class OnSelectedCountChangeedEventArgs : EventArgs
    {
        public ClearCount selectedCounter;
    }

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotateSpeed = 10f; 
    [SerializeField] private GameInput _gameInput;
    [SerializeField] private LayerMask _counterLayerMask;
    private bool _isWalking;
    private Vector3 _lastInteractDir;
    private ClearCount _selectedCount;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("have more than One Player");
        }
        Instance = this;
    }
    private void Start()
    {
        _gameInput.OnInteractAction += GameInput_OnInteractAction;
    }
    private void GameInput_OnInteractAction(object sender, System.EventArgs e)
    {
        if(_selectedCount != null) _selectedCount.Interact();
    }
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
        if(moveDir != Vector3.zero)
        {
            _lastInteractDir = moveDir;
        }
        float interactDistance = 2f;
        if(Physics.Raycast(transform.position, _lastInteractDir, out RaycastHit raycastHit, interactDistance, _counterLayerMask))
        {
            if(raycastHit.transform.TryGetComponent(out ClearCount clearCount))
            {//找到了ClearCount这个物体并且尝试获取ClearCount脚本信息
                if(clearCount != _selectedCount)
                {
                    SetSelectedCounter(clearCount);
                }
            }
            else
            {//找到了ClearCount但是没有ClearCount这个物体脚本的信息
                SetSelectedCounter(null);
            }
        }
        else
        {//射线没有找到ClearCount
            SetSelectedCounter(null);
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

    private void SetSelectedCounter(ClearCount selectedCount)
    {
        _selectedCount = selectedCount;
        OnSelectedCountChangeed?.Invoke(this, new OnSelectedCountChangeedEventArgs
        {
            selectedCounter = selectedCount
        });
    }
}
