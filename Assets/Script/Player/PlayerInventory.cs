using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private RectTransform inventoryObj;

    private inventoryState currentInventoryState = inventoryState.Close;

    public enum inventoryState
    {
        Open,
        Close,
    }
    private void Start()
    {
        currentInventoryState = inventoryState.Close;
        inventoryObj.gameObject.SetActive(false);
    }

    public inventoryState GetCurrentInventoryState()
    {
        return currentInventoryState;
    }

    public void ToggleInventory()
    {
        if(currentInventoryState == inventoryState.Close)
        {
            SoundManager.instance.PlayInventoryOpenSfx();
            currentInventoryState = inventoryState.Open;
            inventoryObj.gameObject.SetActive(true);
        }
        else
        {
            SoundManager.instance.PlayInventoryCloseSfx();
            currentInventoryState = inventoryState.Close;
            inventoryObj.gameObject.SetActive(false);
        }
    }
}
