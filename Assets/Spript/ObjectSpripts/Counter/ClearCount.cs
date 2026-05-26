using UnityEngine;

public class ClearCount : BaseCount, IKitchenObjectParent
{
    [SerializeField] private Transform _countTopPoint;
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;


    private KitchenObject _kitchenObject;

    public override void Interact(Player player)
    {
        if(_kitchenObject == null)
        {
            Debug.Log("Interact!");
            Transform kitchenObjectTransform = Instantiate(_kitchenObjectSO.prefab, _countTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);

        }
        else
        {//玩家拿取物品
           _kitchenObject.SetKitchenObjectParent(player);
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
    public KitchenObject GetKitchenObject()
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
