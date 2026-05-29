using System;
using UnityEngine;

public class ContainCount : BaseCount, IKitchenObjectParent
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;


     public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {//Player not carring anything
            KitchenObject.SpawnKitchenObject(_kitchenObjectSO, player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
            
    }
    
}
