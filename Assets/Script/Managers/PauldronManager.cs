using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauldronManager : MonoBehaviour
{
    private PauldronManager instance;

    public static Action<Ingredient> onAddingIngredientIntoPauldron;

    [SerializeField] private Button mixPauldrenButton;

    private List<Ingredient> ingredientInPauldronList = new List<Ingredient>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        onAddingIngredientIntoPauldron += AddingIngredientIntoPauldron;
        mixPauldrenButton.onClick.AddListener(MixIngredient);
    }

    private void OnDisable()
    {
        onAddingIngredientIntoPauldron -= AddingIngredientIntoPauldron;
        mixPauldrenButton.onClick.RemoveListener(MixIngredient);
    }

    private void MixIngredient()
    {
        ingredientInPauldronList.Clear();
    }

    private void AddingIngredientIntoPauldron(Ingredient ingredient)
    {
        ingredientInPauldronList.Add(ingredient);
    }
}
