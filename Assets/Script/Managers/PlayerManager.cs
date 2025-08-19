using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private PlayerStat playerStat;

    [SerializeField] private IngredientManager playerIngredientManager;

    [SerializeField] private PotionManager playerPotionManager;

    public Action<bool> playerInventoryIsOpen;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenPlayerIngredientInventory();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            OpenPlayerPotionInventory();
        }
    }

    private bool IsPlayerInventoryOpen()
    {
        return playerPotionManager.GetPotionInventory().GetCurrentInventoryState() == PlayerInventory.inventoryState.Open || playerIngredientManager.GetIngredientInventory().GetCurrentInventoryState() == PlayerInventory.inventoryState.Open;
    }

    private void OpenPlayerIngredientInventory()
    {
        playerIngredientManager.GetIngredientInventory().ToggleInventory();
        playerInventoryIsOpen?.Invoke(IsPlayerInventoryOpen());
        PlayerLook.enablePlayerMouseLook?.Invoke(!IsPlayerInventoryOpen());
    }

    private void OpenPlayerPotionInventory()
    {
        playerPotionManager.GetPotionInventory().ToggleInventory();
        playerInventoryIsOpen?.Invoke(IsPlayerInventoryOpen());
        PlayerLook.enablePlayerMouseLook?.Invoke(!IsPlayerInventoryOpen());
        
    }

    public PlayerStat GetPlayerStat()
    {
        return playerStat;
    }


}
