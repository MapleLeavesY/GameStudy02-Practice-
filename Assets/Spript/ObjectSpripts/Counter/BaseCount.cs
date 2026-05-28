using UnityEngine;

public class BaseCount : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private Transform _countTopPoint;

    private KitchenObject _kitchenObject;
    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter Interact();");
    }
    public virtual void InteractAlternate(Player player)
    {
        Debug.LogError("BaseCounter InteractAlternate();");
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
