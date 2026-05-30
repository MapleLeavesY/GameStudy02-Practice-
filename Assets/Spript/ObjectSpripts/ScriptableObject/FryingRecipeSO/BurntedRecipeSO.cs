using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


[CreateAssetMenu()]
public class BurntedRecipeSO : ScriptableObject
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float BurntTimerMax;
}
