
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> _validKitchenObjectList;
    private List<KitchenObjectSO> _kitchenObjectSOList = new List<KitchenObjectSO>();

    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if(!_validKitchenObjectList.Contains(kitchenObjectSO))
        {//Not a valid ingredient
            return false;
        }
        if(_kitchenObjectSOList.Contains(kitchenObjectSO))
        {//Already has this type
            return false;
        }
        else
        {
            _kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
    }
}
