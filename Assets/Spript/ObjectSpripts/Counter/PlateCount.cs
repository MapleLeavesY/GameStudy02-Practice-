using System;
using UnityEngine;


public class PlateCount : BaseCount
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    [SerializeField] private KitchenObjectSO _platechenObjectSO;


    private float _spawnPlateTimer;
    private const float SPAWN_PLATETIMER_MAX = 5f; 
    private int _plateSpawnedAmount;
    private const int _PLATE_SPAWNED_AMOUNT_MAX = 4;
    private void Update()
    {
        _spawnPlateTimer += Time.deltaTime;
        if(_spawnPlateTimer > SPAWN_PLATETIMER_MAX)
        {
            _spawnPlateTimer = 0f;
            if(_plateSpawnedAmount < _PLATE_SPAWNED_AMOUNT_MAX)
            {
                _plateSpawnedAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if(!player.HasKitchenObject())
        {//Player is empty handed
            if(_plateSpawnedAmount > 0)
            {//There's at least one plate here
                _plateSpawnedAmount--;
                KitchenObject.SpawnKitchenObject(_platechenObjectSO, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }

}
