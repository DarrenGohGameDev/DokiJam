using UnityEngine;

[CreateAssetMenu(fileName = "BaseIngredientStat", menuName = "ScriptableObjects/Ingredient/BaseIngredientStat")]
public class BaseIngredientStatScriptableObject : BaseStackableItemScriptableObject
{
    public Ingredient ingredientType;
    public enum Ingredient
    {
        ingredient0 = 0,
        ingredient1 = 1,
        ingredient2 = 2,
        ingredient3 = 3,
    }
}
