using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : ItemManager<Potion>
{
    [SerializeField] protected List<RawImage> itemIconlist = new List<RawImage>();

    public static Action<int> onPotionUsed;

    public static Action<int> onPotionCrafted;

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
        onPotionUsed += RemovePotion;
        onPotionCrafted += CraftingPotion;
    }

    private void OnDisable()
    {
        onPotionUsed -= RemovePotion;
        onPotionCrafted -= CraftingPotion;
    }

    public void SpawnItemIcon()
    {
        for (int i = 0; i < managingItemList.Count; i++)
        {
            itemIconlist[i].texture = managingItemList[i].GetPotionStat().itemIcon;
        }
    }

    private void CraftingPotion(int id)
    {
        Potion potion = managingItemList.FirstOrDefault(x => id == (int)x.GetPotionStat().PotionType);

        if (potion == null)
        {
            // pop up potion unsuccefully crafted
            Debug.Log("no potion match");
            return;
        }

        int potionTotalStack = potion.GetPotionStat().totalStack;
        int potionMaxStack = potion.GetPotionStat().maxStack;

        if (potionTotalStack < potionMaxStack)
        {
            potion.GetPotionStat().totalStack++;
        }
    }

    private void RemovePotion(int id)
    {
        Potion potion = managingItemList.FirstOrDefault(x => id == (int)x.GetPotionStat().PotionType);

        potion.GetPotionStat().totalStack--;
    }
}
