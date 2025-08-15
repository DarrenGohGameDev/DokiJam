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
        DragableManager.onBeginDragIngredient?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        DragableManager.onStopDragingIngredient?.Invoke();

        Ray ray = Camera.main.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject.CompareTag("Pauldron"))
            {
                Debug.Log("Dropped on " + hit.collider.name);
                PauldronManager.onAddingIngredientIntoPauldron?.Invoke(this);
            }
            
        }
    }
}
