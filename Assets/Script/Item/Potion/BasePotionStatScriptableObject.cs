using UnityEngine;

[CreateAssetMenu(fileName = "BasePotionStat", menuName = "ScriptableObjects/Potion/BasePotionStat")]
public class BasePotionStatScriptableObject : BaseStackableItemScriptableObject
{
    public PotionType potionType;
    public enum PotionType
    {
        Potion3 = 3,
        Potion10 = 10,
        Potion11 = 11,
        Potion12 = 12,
        Potion13 = 13,
        Potion15 = 15,
        Potion16 = 16,
        Potion17 = 17,
        Potion18 = 18,
        Potion19 = 19,
        Potion20 = 20,
        Potion21 = 21,
        Potion22 = 22,
        Potion23 = 23,
        Potion24 = 24,
        Potion25 = 25,
    }
}
