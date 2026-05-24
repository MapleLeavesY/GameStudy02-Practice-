using UnityEngine;

public class ClearCount : MonoBehaviour
{
    [SerializeField] private Transform _countTopPoint;
    [SerializeField] private KitchenObjectSO _kitchenObjectSO;
    public void Interact()
    {
        Debug.Log("Interact!");
        Transform kitchenObjectTransform = Instantiate(_kitchenObjectSO.prefab, _countTopPoint);
        kitchenObjectTransform.localPosition = Vector3.zero;

        Debug.Log(kitchenObjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }
}
