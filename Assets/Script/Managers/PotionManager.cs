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
        onPotionCrafted += AddPotion;
    }

    private void OnDisable()
    {
        onPotionUsed -= RemovePotion;
        onPotionCrafted -= AddPotion;
    }

    public void SpawnItemIcon()
    {
        for (int i = 0; i < managingItemList.Count; i++)
        {
            itemIconlist[i].texture = managingItemList[i].GetPotionStat().itemIcon;
        }
    }

    private void AddPotion(int id)
    {
        Potion potion = managingItemList.First(x => id == (int)x.GetPotionStat().PotionType);

        potion.GetPotionStat().totalStack++;
    }

    private void RemovePotion(int id)
    {
        Potion potion = managingItemList.First(x => id == (int)x.GetPotionStat().PotionType);

        potion.GetPotionStat().totalStack--;
    }
}
