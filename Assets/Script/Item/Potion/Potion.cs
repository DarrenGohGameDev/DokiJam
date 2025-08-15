using UnityEngine;
using UnityEngine.EventSystems;

public class Potion : BaseDragableItem
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BasePotionStatScriptableObject GetPotionStat()
    {
        return (BasePotionStatScriptableObject)GetDragableItemStat();
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
            if (hit.collider.gameObject.CompareTag("Customer"))
            {

            }
        }
    }
}