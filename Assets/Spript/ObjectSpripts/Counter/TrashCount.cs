
using UnityEngine;

public class TrashCount : BaseCount
{
    public override void Interact(Player player)
    {
        if(player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
        }
    }
}
