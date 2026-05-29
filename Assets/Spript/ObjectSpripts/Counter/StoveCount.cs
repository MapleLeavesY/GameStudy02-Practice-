using UnityEngine;

public class StoveCount : BaseCount
{
    private enum State
    {
        Idle,
        Frying,
        Fried,
        Burnted
    }
    [SerializeField] private FryingRecipeSO[] _fryingRecipeSOArray;

    private State _state;
    private float _fryingTimer;
    private FryingRecipeSO _fryingRecipeSO;
    private void Start()
    {
        _state = State.Idle;
    }
    private void Update()
    {
        if(HasKitchenObject())
        {
            switch(_state)
            {
                case State.Idle:

                    break;
                case State.Frying:
                    _fryingTimer += Time.deltaTime;
                    if(_fryingTimer > _fryingRecipeSO.FryingtimerMax)
                    {//Fried
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(_fryingRecipeSO.output, this);
                        Debug.Log("Object fried");
                        _state = State.Fried;
                    }
                    break;
                case State.Fried:

                    break;
                case State.Burnted:

                    break;   
            } 
            Debug.Log(_state);
        }
    }
    public override void Interact(Player player)
    {
        if(!HasKitchenObject())
        {//Not have KitchenObject here
            if(player.HasKitchenObject())
            {//Player Carrying KitchenObject
                if(HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {//Player carrying something Can Frying KitchenObject
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    
                    _fryingRecipeSO = GetFryingRecipeWithInput(GetKitchenObject().GetKitchenObjectSO());
                    _state = State.Frying;
                    _fryingTimer = 0f;
                }
            }
        }
        else
        {
            if(player.HasKitchenObject())
            {//Player is Carrying something
                
            }
            else
            {//Player is not Carrying something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeWithInput(inputKitchenObjectSO);
        if(fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    private FryingRecipeSO GetFryingRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach(FryingRecipeSO fryingRecipeSO in _fryingRecipeSOArray)
        {
            if(fryingRecipeSO.input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }
}
    
