using System;
using UnityEngine;

public class PatienceMeter : MonoBehaviour
{
    public static Action<float> setPatienceMeter;

    private float maxPatience;

    private float currentPatience;

    private float patienceMinusValue;

    private void Start()
    {
        
    }

    private void Update()
    {
        setPatienceMeter?.Invoke(-patienceMinusValue);
    }

    private void OnEnable()
    {
        setPatienceMeter += SetPatienceMeterValue;
    }

    private void OnDisable()
    {
        setPatienceMeter -= SetPatienceMeterValue;
    }

    public void SetPatienceValue(float maxPatienceValue, float minusPatienceValue)
    {
        maxPatience = maxPatienceValue;
        currentPatience = maxPatience;
        patienceMinusValue = minusPatienceValue;
    }

    private void SetPatienceMeterValue(float value)
    {
        currentPatience += value;
    }
}
