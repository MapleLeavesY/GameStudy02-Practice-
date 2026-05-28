
using UnityEngine;

public class CuttingCount : BaseCount
{
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
                
            }
            else
            {//Player is not Carring something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject())
        {//There is a KitchenObject here
            GetKitchenObject().DestroySelf();
        }
    }
}
