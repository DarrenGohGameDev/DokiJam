using UnityEngine;

[CreateAssetMenu(fileName = "BasePotionStat", menuName = "ScriptableObjects/Potion/BasePotionStat")]
public class BasePotionStatScriptableObject : BaseStackableItemScriptableObject
{
    public Potion PotionType;
    public enum Potion
    {
        Potion0 = 0,
        Potion1 = 1,
        Potion2 = 2,
        Potion3 = 3,
    }
}
