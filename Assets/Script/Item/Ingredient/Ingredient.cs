using UnityEngine;
using UnityEngine.EventSystems;

public class Ingredient : MonoBehaviour  , IBeginDragHandler , IDragHandler , IEndDragHandler 
{
    [SerializeField] private BaseIngredientStatScriptableObject ingredientStat;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public BaseIngredientStatScriptableObject GetIngredientStat()
    {
        return ingredientStat;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("begin drag");
        DragableManager.onBeginDragIngredient?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("end drag");
        DragableManager.onStopDragingIngredient?.Invoke();
    }

    
}
