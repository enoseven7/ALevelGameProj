using System.Collections.Generic;

public class DeckInstance
{
    private List<CardScriptableObject> drawPile;
    private List<CardScriptableObject> hand;
    private List<CardScriptableObject> discardPile;

    public IReadOnlyList<CardScriptableObject> Hand => hand;

    public DeckInstance(DeckScriptableObject baseDeck)
    {
        drawPile = new List<CardScriptableObject>(baseDeck.TotalCards);
        hand = new List<CardScriptableObject>();
        discardPile = new List<CardScriptableObject>();

        Shuffle();
        Draw(5); // Example: start with 5 cards in hand
    }

    public void Shuffle()
    {
        for (int i = 0; i < drawPile.Count; i++)
        {
            var temp = drawPile[i];
            int randomIndex = UnityEngine.Random.Range(i, drawPile.Count);
            drawPile[i] = drawPile[randomIndex];
            drawPile[randomIndex] = temp;
        }
    }

    public void Draw(int amount)
    {
        for (int i = 0; i < amount && drawPile.Count > 0; i++)
        {
            var card = drawPile[0];
            drawPile.RemoveAt(0);
            hand.Add(card);
        }
    }

    public void Discard(CardScriptableObject card)
    {
        if (hand.Remove(card))
            discardPile.Add(card);
    }
}
