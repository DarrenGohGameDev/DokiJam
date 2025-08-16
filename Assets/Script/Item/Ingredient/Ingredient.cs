using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Ingredient : BaseDragableItem
{

    void Start()
    {
        this.GetComponent<RawImage>().texture = GetDragableItemStat().itemIcon;
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
        base.OnBeginDragItem(eventData);
        DragableManager.onBeginDragIngItem?.Invoke(this);
    }

    protected override void OnEndDragItem(PointerEventData eventData)
    {
        base.OnEndDragItem(eventData);
        DragableManager.onStopDragingItem?.Invoke();

        Ray ray = Camera.main.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if(hit.collider.gameObject.CompareTag("Pauldron"))
            {
                PauldronManager.onAddingIngredientIntoPauldron?.Invoke(this);
                SoundManager.instance.PlayAddingIngredientSfx();
            }
            
        }
    }
}
