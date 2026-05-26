using UnityEngine;

public class BaseCount : MonoBehaviour
{
    public virtual void Interact(Player player)
    {
        Debug.LogError("BaseCounter Interact();");
    }
}
