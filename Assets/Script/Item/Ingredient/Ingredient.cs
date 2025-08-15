using UnityEngine;
using UnityEngine.EventSystems;

public class Ingredient : BaseDragableItem
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public BaseIngredientStatScriptableObject GetIngredientStat()
    {
        return (BaseIngredientStatScriptableObject)GetDragableItemStat();
    }

    protected override void OnBeginDragItem(PointerEventData eventData)
    {
        DragableManager.onBeginDragIngItem?.Invoke(this);
    }

    protected override void OnEndDragItem(PointerEventData eventData)
    {
        DragableManager.onStopDragingItem?.Invoke();

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
