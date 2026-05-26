using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    
    private ClearCount _clearCount;
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return _kitchenObjectSO;
    }
    public void SetClearCounter(ClearCount clearCount)
    {
        _clearCount = clearCount;
        

    }
    public ClearCount GetClearCounter()
    {
        return _clearCount;
    }
}
 