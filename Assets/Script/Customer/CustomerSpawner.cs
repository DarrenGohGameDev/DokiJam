using NUnit.Framework;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private List<Mesh> customerModelList = new List<Mesh>();

    [SerializeField] private GameObject customer;

    [SerializeField] private List<Transform> customerSpawnPoint = new List<Transform>(); // start position , counter position , Exit Map position

    [SerializeField] private float spawnCustomerTimer = 10f;

    [SerializeField] private int maxSpawnCustomer = 10;

    private float currentSpawnCustomerTimer;

    private List<int> potionId = new List<int>();

    private int totalCustomerAlive = 0;

    public static Action<int> customerAlive;

    
    void Start()
    {
        potionId = PotionManager.GetAllPotionIdList();
        currentSpawnCustomerTimer = spawnCustomerTimer;
    }

    void Update()
    {
        spawnCustomerTimer -= Time.deltaTime;
        if(currentSpawnCustomerTimer <= 0 && totalCustomerAlive < maxSpawnCustomer)
        {
            SpawnCustomer();
        }
    }

    private void OnEnable()
    {
        customerAlive += SetTotalCustomerAlive;
    }
    private void OnDisable()
    {
        customerAlive -= SetTotalCustomerAlive;
    }

    private void SpawnCustomer()
    {
        Instantiate(GetNewCustomer(), customerSpawnPoint[0]);

        customerAlive?.Invoke(1);

        currentSpawnCustomerTimer = spawnCustomerTimer;
    }

    private BaseCustomer GetNewCustomer()
    {
        // set new customer stat
        BaseCustomer newCustomer = customer.GetComponent<BaseCustomer>();
        newCustomer.gameObject.GetComponent<MeshFilter>().mesh = customerModelList[UnityEngine.Random.Range(0, customerModelList.Count)];
        newCustomer.SetCustomerMovePosition(GetCustomerMovePosition());
        newCustomer.SetCorrectOrderPotionId(potionId[UnityEngine.Random.Range(0, potionId.Count)]);

        return newCustomer;
    }

    private List<Transform> GetCustomerMovePosition()
    {
        return customerSpawnPoint;
    }

    private void SetTotalCustomerAlive(int value)
    {
        totalCustomerAlive += value;
    }
}
