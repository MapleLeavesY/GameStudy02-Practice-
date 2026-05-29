using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float FryingtimerMax;
}
