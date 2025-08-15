using System;
using UnityEngine;
using UnityEngine.UI;

public class DragableManager : MonoBehaviour
{
    private Ingredient dragingIngredient;

    [SerializeField] private RawImage cursorIngredientIcon;

    public static Action<Ingredient> onBeginDragIngredient;

    public static Action onStopDragingIngredient;

    private bool ingredientIconFollowCursor = false;

    void Awake()
    {
        ResetCursorIngredientIcon();
    }

    void Update()
    {
        if(ingredientIconFollowCursor)
        {
            cursorIngredientIcon.transform.position = Input.mousePosition;
        }
    }

    private void OnEnable()
    {
        onBeginDragIngredient += RegisterDragingIngredient;
        onStopDragingIngredient += ClearDragingIngredient;
    }

    private void OnDisable()
    {
        onBeginDragIngredient -= RegisterDragingIngredient;
        onStopDragingIngredient -= ClearDragingIngredient;
    }

    private void RegisterDragingIngredient(Ingredient ingredient)
    {
        dragingIngredient = ingredient;
        cursorIngredientIcon.texture = ingredient.GetIngredientStat().itemIcon;
        cursorIngredientIcon.gameObject.SetActive(true);
        ingredientIconFollowCursor = true;
    }

    private void ClearDragingIngredient()
    {
        dragingIngredient = null;
        ResetCursorIngredientIcon();
        ingredientIconFollowCursor = false;
    }

    private void ResetCursorIngredientIcon()
    {
        cursorIngredientIcon.gameObject.SetActive(false);
    }
}
