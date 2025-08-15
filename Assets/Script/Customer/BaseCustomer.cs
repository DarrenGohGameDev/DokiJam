using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BaseCustomer : MonoBehaviour
{
    private int correctOrderPotionId;

    private CustomerState currentCustomerState = CustomerState.idle;

    private List<Transform> movePosition = new List<Transform>();

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
        if (correctOrderPotionId != potionId)
            return;

        currentCustomerState = CustomerState.leavingShop;
    }

    public void SetCustomerMovePosition(List<Transform> newMovePosition)
    {
        movePosition = newMovePosition;
    }

    public void SetCorrectOrderPotionId(int correctPotionId)
    {
        correctOrderPotionId = correctPotionId;
    }

    private void LeaveMap()
    {
        CustomerSpawner.customerAlive?.Invoke(-1);
    }
}