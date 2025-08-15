using UnityEngine;
using UnityEngine.EventSystems;

public class BaseDragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private BaseItemStatScriptableObject itemStat;
    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragItem(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragItem(eventData);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragItem(eventData);
    }

    protected virtual void OnBeginDragItem(PointerEventData eventData)
    {

    }

    protected virtual void OnDragItem(PointerEventData eventData)
    {

    }

    protected virtual void OnEndDragItem(PointerEventData eventData)
    {

    }

    public BaseItemStatScriptableObject GetDragableItemStat()
    {
        return itemStat;
    }
}
