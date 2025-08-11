using UnityEngine;

[CreateAssetMenu(fileName = "BaseItemStat", menuName = "ScriptableObjects/Item/BaseItemStat")]
public class BaseItemStatScriptableObject : ScriptableObject
{
    public string itemName;
    public string itemDescription;
    public Texture2D itemIcon;
}