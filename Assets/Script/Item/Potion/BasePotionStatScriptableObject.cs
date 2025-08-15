using UnityEngine;

[CreateAssetMenu(fileName = "BasePotionStat", menuName = "ScriptableObjects/Potion/BasePotionStat")]
public class BasePotionStatScriptableObject : BaseStackableItemScriptableObject
{
    public PotionType potionType;
    public enum PotionType
    {
        Potion0 = 0,
        Potion1 = 1,
        Potion2 = 2,
        Potion3 = 3,
    }
}
