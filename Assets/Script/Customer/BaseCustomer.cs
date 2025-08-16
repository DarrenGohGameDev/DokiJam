using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BaseCustomer : MonoBehaviour
{
    private int correctOrderPotionId;

    [SerializeField] private CustomerState currentCustomerState = CustomerState.idle;

    private List<Transform> movePosition = new List<Transform>();

    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private ChatBubble chatBubble;

    [SerializeField] private float agentNearCounterDistance = 0.03f;

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
        currentCustomerState = CustomerState.walkingToShop;
        agent.SetDestination(movePosition[1].position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.hasPath && agent.remainingDistance <= agentNearCounterDistance)
        {
            switch (currentCustomerState)
            {
                case CustomerState.walkingToShop:
                    currentCustomerState = CustomerState.orderingPotion;
                    chatBubble.ToggleChatBubble(true, PotionManager.instance.GetPotionIconFromPotionId(correctOrderPotionId));
                    break;

                case CustomerState.leavingShop:
                    LeaveMap();
                    break;
            }
        }
    }

    public void ReceivePotion(int potionId)
    {
        if (GameManager.instance.gameState != GameManager.GameState.StartGame)
            return;

        if (currentCustomerState != CustomerState.orderingPotion)
            return;

        if (correctOrderPotionId != potionId)
            return;

        currentCustomerState = CustomerState.leavingShop;
        chatBubble.ToggleChatBubble(false, null);
        agent.SetDestination(movePosition[2].position);
        GameManager.instance.OnDragoonOrderComplete();
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
        Destroy(this.gameObject);
    }
}