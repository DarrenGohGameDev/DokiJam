using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    private int orderPotionId;

    private CustomerState currentCustomerState = CustomerState.idle;

    private enum CustomerState
    {
        idle,
        walkingToShop,
        orderingPotion,
        leavingShop,
        byStander,
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceivePotion(int potionId)
    {
        if (orderPotionId != potionId)
            return;

        currentCustomerState = CustomerState.leavingShop;
    }
}