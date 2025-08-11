using UnityEngine;

[CreateAssetMenu(fileName = "BaseItemStat", menuName = "ScriptableObjects/Item/BaseIngredientStat")]
public class BaseIngredientStatScriptableObject : BaseItemScriptableObject
{
    public int totalStack;
    public int maxStack;
}
