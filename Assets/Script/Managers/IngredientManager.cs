using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class IngredientManager : ItemManager<Ingredient>
{

    public static Action<int> onIngredientUsed;

    public static Action<int> onIngredientAdded;

    [SerializeField] private PlayerInventory ingredientInventory;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        onIngredientUsed += RemoveIngredient;
        onIngredientAdded += AddIngredient;
    }

    private void OnDisable()
    {
        onIngredientUsed -= RemoveIngredient;
        onIngredientAdded -= AddIngredient;
    }

    public PlayerInventory GetIngredientInventory()
    {
        return ingredientInventory;
    }

    private void AddIngredient(int id)
    {
        Ingredient ingredient = managingItemList.First(x => id == (int)x.GetIngredientStat().ingredientType);

        ingredient.GetIngredientStat().totalStack++;
    }

    private void RemoveIngredient(int id)
    {
        Ingredient ingredient = managingItemList.First(x => id == (int)x.GetIngredientStat().ingredientType);

        ingredient.GetIngredientStat().totalStack--;
    }
}
