using UnityEngine;

public class ClearCount : BaseCount
{
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;


    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {//Not have KitchenObject here
            if(player.HasKitchenObject())
            {//Player Carring KitchenObject
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
        }
        else
        {//There is a KitchenObject here
            if(player.HasKitchenObject())
            {//Player is Carring something
                if(player.GetKitchenObject() is PlateKitchenObject)
                {// Player is holding a Plate
                     PlateKitchenObject plateKitchenObject = player.GetKitchenObject() as PlateKitchenObject;

                     if(plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();
                    }

                }
            }
            else
            {//Player is not Carring something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }

    }
    
}
