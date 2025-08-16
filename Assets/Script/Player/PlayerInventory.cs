using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private RectTransform inventoryObj;

    private inventoryState currentInventoryState = inventoryState.Close;

    private enum inventoryState
    {
        Open,
        Close,
    }
    private void Start()
    {
        currentInventoryState = inventoryState.Close;
        inventoryObj.gameObject.SetActive(false);
    }

    public void ToggleInventory()
    {
        if(currentInventoryState == inventoryState.Close)
        {
            currentInventoryState = inventoryState.Open;
            inventoryObj.gameObject.SetActive(true);
            PlayerLook.enablePlayerMouseLook?.Invoke(false);
        }
        else
        {
            currentInventoryState = inventoryState.Close;
            inventoryObj.gameObject.SetActive(false);
            PlayerLook.enablePlayerMouseLook?.Invoke(true);
        }
    }
}
