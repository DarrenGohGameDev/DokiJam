using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PotionManager : ItemManager<Potion>
{
    public static PotionManager instance;

    [SerializeField] private PlayerInventory potionInventory;

    public Action<int> onPotionUsed;

    public Action<int> onPotionCrafted;

    private void Awake()
    {
        if (instance != this)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        SetAllPotionStackText();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            potionInventory.ToggleInventory();
        }
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

    private void SetAllPotionStackText()
    {
        for (int i = 0; i < managingItemList.Count; i++)
        {
            managingItemList[i].SetPotionStackText(managingItemList[i].GetPotionStat().totalStack);
        }
    }

    public void ResetAllPotion()
    {
        for (int i = 0; i < managingItemList.Count; i++)
        {
            managingItemList[i].GetPotionStat().totalStack = 0;
        }
    }

    private void CraftingPotion(int id)
    {
        Potion potion = managingItemList.FirstOrDefault(x => id == (int)x.GetPotionStat().potionType);

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
            potion.SetPotionStackText(potionTotalStack);
        }
    }

    private void RemovePotion(int id)
    {
        Potion potion = managingItemList.FirstOrDefault(x => id == (int)x.GetPotionStat().potionType);

        potion.GetPotionStat().totalStack--;
    }

    public List<int> GetAllPotionIdList()
    {
        List<int> allPotionIdList = new List<int>();

        foreach(int potionId in Enum.GetValues(typeof(BasePotionStatScriptableObject.PotionType)))
        {
            allPotionIdList.Add(potionId);
        }

        return allPotionIdList;
    }

    private Potion GetPotionFromPotionId(int id)
    {
        Potion potion = null;
        for (int i = 0; i < managingItemList.Count; i++)
        {
            if((int)managingItemList[i].GetPotionStat().potionType == id)
            {
                potion = managingItemList[i];
            }
        }

        return potion;
    }

    public Texture2D GetPotionIconFromPotionId(int id)
    {
        return GetPotionFromPotionId(id).GetPotionStat().itemIcon;
    }
}
