using System;
using UnityEngine;

public class StoveCount : BaseCount, IHasProgress
{

    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public class OnStateChangedEventArgs : EventArgs
    {
        public State state;
    }
    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burnted
    }
    [SerializeField] private FryingRecipeSO[] _fryingRecipeSOArray;
    [SerializeField] private BurntedRecipeSO[] _bruntingRecipeSOArray;

    private State _state;
    private float _fryingTimer;
    private float _burntTimer;
    private FryingRecipeSO _fryingRecipeSO;
    private BurntedRecipeSO _burntingRecipeSO;
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

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = _fryingTimer / _fryingRecipeSO.FryingTimerMax
                    });

                    if(_fryingTimer > _fryingRecipeSO.FryingTimerMax)
                    {//Fried
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(_fryingRecipeSO.output, this);
                        _burntTimer = 0f;
                        _state = State.Fried;
                        _burntingRecipeSO = GetBurntRecipeWithInput(GetKitchenObject().GetKitchenObjectSO());

                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = _state
                        });
                    }
                    break;
                case State.Fried:
                    _burntTimer += Time.deltaTime;
                    
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = _burntTimer / _burntingRecipeSO.BurntTimerMax
                    });

                    if(_burntTimer > _burntingRecipeSO.BurntTimerMax)
                    {//Fried
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(_burntingRecipeSO.output, this);
                        _state = State.Burnted;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = _state
                        });
                        OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                        {
                            progressNormalized = 0f
                        });
                        
                    }
                    break;
                case State.Burnted:
                    break;   
            } 
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

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = _state
                    });

                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        progressNormalized = _fryingTimer / _fryingRecipeSO.FryingTimerMax
                    });
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
                _state = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                {
                    state = _state
                });
                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    progressNormalized = 0f
                });
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
    private BurntedRecipeSO GetBurntRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach(BurntedRecipeSO burntingRecipeSO in _bruntingRecipeSOArray)
        {
            if(burntingRecipeSO.input == inputKitchenObjectSO)
            {
                return burntingRecipeSO;
            }
        }
        return null;
    }
}
    
