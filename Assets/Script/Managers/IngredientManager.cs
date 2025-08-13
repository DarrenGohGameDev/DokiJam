using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class IngredientManager : ItemManager<Ingredient>
{
    [SerializeField] protected List<RawImage> itemIconlist = new List<RawImage>();

    public static Action<int> onIngredientUsed;

    public static Action<int> onIngredientAdded;

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
        onIngredientUsed += RemovePotion;
        onIngredientAdded += AddPotion;
    }

    private void OnDisable()
    {
        onIngredientUsed -= RemovePotion;
        onIngredientAdded -= AddPotion;
    }

    public void SpawnItemIcon()
    {
        for (int i = 0; i < managingItemList.Count; i++)
        {
            itemIconlist[i].texture = managingItemList[i].GetIngredientStat().itemIcon;
        }
    }

    private void AddPotion(int id)
    {
        Ingredient potion = managingItemList.First(x => id == (int)x.GetIngredientStat().ingredientType);

        potion.GetIngredientStat().totalStack++;
    }

    private void RemovePotion(int id)
    {
        Ingredient potion = managingItemList.First(x => id == (int)x.GetIngredientStat().ingredientType);

        potion.GetIngredientStat().totalStack--;
    }
}
