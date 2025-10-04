using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpeedDiceSlotUI : MonoBehaviour, IDropHandler
{
    public int slotIndex;
    public UnitInstance Owner { get; private set; }
    public CardScriptableObject AssignedCard { get; private set; }

    public SpeedDieSlot slot;

    public BattleManager battleManager;

    public void Init(UnitInstance owner, int index)
    {
        Owner = owner;
        slotIndex = index;
        AssignedCard = null;
        battleManager = FindFirstObjectByType<BattleManager>();
    }

    public void AssignCard(CardDrag cardDrag)
    {
        slot.AssignedCard = cardDrag.CardData;

        if (battleManager.currentlySelected.unitName == Owner.unitName)
        {
            Debug.Log("Assigned card");
            Debug.Log(battleManager.currentlySelected.unitName);
            gameObject.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            Debug.Log("Can't do that");
        }
        
    }


    public void OnDrop(PointerEventData eventData)
    {
        CardDrag dragged = eventData.pointerDrag?.GetComponent<CardDrag>();
        if (dragged == null) return;

        AssignedCard = dragged.CardData;
    }

    public void Clear()
    {
        AssignedCard = null;
    }
}
