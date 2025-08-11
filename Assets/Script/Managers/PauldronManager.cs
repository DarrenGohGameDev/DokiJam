using System;
using UnityEngine;
using UnityEngine.UI;

public class PauldronManager : MonoBehaviour
{
    public static Action onDropingIngrendient;

    [SerializeField] Button mixPauldrenButton;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        mixPauldrenButton.onClick.AddListener(MixIngredient);
    }

    private void OnDisable()
    {
        mixPauldrenButton.onClick.RemoveListener(MixIngredient);
    }

    private void MixIngredient()
    {

    }
}
