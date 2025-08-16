using UnityEngine;

[CreateAssetMenu(fileName = "BaseIngredientStat", menuName = "ScriptableObjects/Ingredient/BaseIngredientStat")]
public class BaseIngredientStatScriptableObject : BaseStackableItemScriptableObject
{
    public Ingredient ingredientType;
    public enum Ingredient
    {
        ingredient1 = 1,
        ingredient2 = 2,
        ingredient3 = 3,
        ingredient4 = 4,
        ingredient5 = 5,
        ingredient6 = 6,
        ingredient7 = 7,
        ingredient8 = 8,
        ingredient9 = 9,
        ingredient10 = 10,
        ingredient11 = 11,
        ingredient12 = 12,
        ingredient13 = 13,
        ingredient14 = 14,
        ingredient15 = 15,
        ingredient16 = 16,
    }
}
