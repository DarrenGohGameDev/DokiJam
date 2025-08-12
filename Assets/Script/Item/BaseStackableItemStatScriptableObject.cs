using UnityEngine;

[CreateAssetMenu(fileName = "BaseStackableItemStat", menuName = "ScriptableObjects/Item/BaseStackableItemStat")]
public class BaseStackableItemScriptableObject : BaseItemStatScriptableObject
{
    public int totalStack;
    public int maxStack;
}
