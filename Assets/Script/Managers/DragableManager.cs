using System;
using UnityEngine;
using UnityEngine.UI;

public class DragableManager : MonoBehaviour
{
    private BaseDragableItem dragingItem;

    [SerializeField] private RawImage cursorIngredientIcon;

    public static Action<BaseDragableItem> onBeginDragIngItem;

    public static Action onStopDragingItem;

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
        onBeginDragIngItem += RegisterDragingIngredient;
        onStopDragingItem += ClearDragingIngredient;
    }

    private void OnDisable()
    {
        onBeginDragIngItem -= RegisterDragingIngredient;
        onStopDragingItem -= ClearDragingIngredient;
    }

    private void RegisterDragingIngredient(BaseDragableItem item)
    {
        dragingItem = item;
        cursorIngredientIcon.texture = item.GetDragableItemStat().itemIcon;
        cursorIngredientIcon.gameObject.SetActive(true);
        ingredientIconFollowCursor = true;
    }

    private void ClearDragingIngredient()
    {
        dragingItem = null;
        ResetCursorIngredientIcon();
        ingredientIconFollowCursor = false;
    }

    private void ResetCursorIngredientIcon()
    {
        cursorIngredientIcon.gameObject.SetActive(false);
    }
}
