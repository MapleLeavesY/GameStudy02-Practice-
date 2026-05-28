using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;

public class ContainCount : BaseCount, IKitchenObjectParent
{
    public event EventHandler OnPlayerGrabbedObject;
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;


     public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {//Player not carring anything
            Transform kitchenObjectTransform = Instantiate(_kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
            
    }
    
}
