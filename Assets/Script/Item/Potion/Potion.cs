using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Potion : BaseDragableItem
{
    [SerializeField] private TextMeshProUGUI potionStackText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetPotionStackText(0);
        this.GetComponent<RawImage>().texture = GetDragableItemStat().itemIcon;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public BasePotionStatScriptableObject GetPotionStat()
    {
        return (BasePotionStatScriptableObject)GetDragableItemStat();
    }

    public void SetPotionStackText(int value)
    {
        potionStackText.text = value.ToString();
    }

    protected override void OnBeginDragItem(PointerEventData eventData)
    {
        base.OnBeginDragItem(eventData);
        if (GetPotionStat().totalStack <= 0)
            return;
        DragableManager.onBeginDragIngItem?.Invoke(this);
    }

    protected override void OnEndDragItem(PointerEventData eventData)
    {
        base.OnEndDragItem(eventData);
        if (GetPotionStat().totalStack <= 0)
            return;
        DragableManager.onStopDragingItem?.Invoke();

        Ray ray = Camera.main.ScreenPointToRay(eventData.position);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Customer"))
            {
                hit.collider.gameObject.GetComponentInParent<BaseCustomer>().ReceivePotion((int)GetPotionStat().potionType);
                PotionManager.instance.onPotionUsed?.Invoke((int)GetPotionStat().potionType);
            }
        }
    }
}