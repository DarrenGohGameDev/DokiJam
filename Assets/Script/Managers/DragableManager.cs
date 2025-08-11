using UnityEngine;
using UnityEngine.UI;

public class DragableManager : MonoBehaviour
{
    private Ingredient dragingIngredient;

    [SerializeField] private RawImage cursorIngredientIcon;

    public delegate void OnBeginDragIngredient(Ingredient ingredient);
    public OnBeginDragIngredient onBeginDragIngredient;

    public delegate void OnStopDragingIngredient();
    public OnStopDragingIngredient onStopDragingIngredient;

    private bool ingredientIconFollowCursor = false;

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

    void Start()
    {
        
    }

    void Update()
    {
        if(ingredientIconFollowCursor)
        {
            cursorIngredientIcon.transform.position = Input.mousePosition;
        }
    }

    private void RegisterDragingIngredient(Ingredient ingredient)
    {
        dragingIngredient = ingredient;
        // cursorIngredientIcon = ingredient.itemIcon;
        ingredientIconFollowCursor = true;
    }

    private void ClearDragingIngredient()
    {
        dragingIngredient = null;
    }
}
