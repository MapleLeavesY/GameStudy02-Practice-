using UnityEngine;

public class ClearCount : MonoBehaviour
{
    [SerializeField] private Transform _countTopPoint;
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    [SerializeField] private ClearCount _secondClearCount;
    [SerializeField] private bool testing;

    private KitchenObject _kitchenObject;
    private void Update()
    {
        if(testing && Input.GetKeyDown(KeyCode.T))
        {
            if(_kitchenObject != null)
            {
                _kitchenObject.SetClearCounter(_secondClearCount);
                Debug.Log(_kitchenObject.GetClearCounter());
            }
        }
    }
    public void Interact()
    {
        if(_kitchenObject == null)
        {
            Debug.Log("Interact!");
            Transform kitchenObjectTransform = Instantiate(_kitchenObjectSO.prefab, _countTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            _kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            _kitchenObject.SetClearCounter(this);
        }
        else
        {
            Debug.Log(_kitchenObject.GetClearCounter());
        }
    }
    public Transform GetKitchenObjectFollowTransform()
    {
        return _countTopPoint;
    }
    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        _kitchenObject = kitchenObject;
    }
    public KitchenObject GetKitchenObject(KitchenObject kitchenObject)
    {
        return _kitchenObject;
    }
    public void ClearKitchenObject()
    {
        _kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return _kitchenObject != null;
    }
}
