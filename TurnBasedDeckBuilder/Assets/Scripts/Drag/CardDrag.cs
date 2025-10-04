using UnityEngine;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public CardScriptableObject CardData { get; private set; }

    private CanvasGroup canvasGroup;
    private Transform originalParent;

    public void Init(CardScriptableObject data)
    {
        CardData = data;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;
        canvasGroup = GetComponent<CanvasGroup>();
        if (canvasGroup != null) canvasGroup.blocksRaycasts = false;
        transform.SetParent(transform.root); // drag above UI
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject hitObj = eventData.pointerCurrentRaycast.gameObject;
        transform.SetParent(originalParent);

        if (hitObj != null && hitObj.GetComponent<SpeedDiceSlotUI>() != null)
        {
            Debug.Log("found speed dice");
            hitObj.GetComponent<SpeedDiceSlotUI>().AssignCard(this);
        }

        if (canvasGroup != null) canvasGroup.blocksRaycasts = true;
    }
}
