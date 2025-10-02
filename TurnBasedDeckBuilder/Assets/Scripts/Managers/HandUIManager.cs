using System.Collections.Generic;
using UnityEngine;

public class HandUIManager : MonoBehaviour
{
    [SerializeField] private GameObject cardPrefab;      
    [SerializeField] private Transform handPanel;         

    private List<CardUI> activeCards = new List<CardUI>();

    //clears the hand then adds hards from the currently selected unit
    public void DisplayHand(IReadOnlyList<CardScriptableObject> handData)
    {
        ClearHand();

        foreach (var cardData in handData)
        {
            GameObject cardGO = Instantiate(cardPrefab, handPanel);
            CardUI cardUI = cardGO.GetComponent<CardUI>();

            cardUI.SetCard(cardData);

            activeCards.Add(cardUI);
        }
    }

    // removes cards from the UI
    public void ClearHand()
    {
        foreach (var card in activeCards)
        {
            Destroy(card.gameObject);
        }
        activeCards.Clear();
    }

    // a method to remove a singular card from the hand, for when its played. Will be useful later.
    public void RemoveCard(CardUI cardUI)
    {
        if (activeCards.Contains(cardUI))
        {
            activeCards.Remove(cardUI);
            Destroy(cardUI.gameObject);
        }
    }
}
