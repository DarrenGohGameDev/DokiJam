using UnityEngine;
using System.Collections.Generic;

public class ItemManager<T> : MonoBehaviour
{
    [SerializeField] protected List<T> managingItemList = new List<T>();

    public List<T> GetManagingItemList()
    {
        return managingItemList;
    }
}