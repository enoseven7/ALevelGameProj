using UnityEngine;

[CreateAssetMenu(fileName = "DeckScriptableObject", menuName = "ScriptableObjects/DeckScriptableObject")]
public class DeckScriptableObject : ScriptableObject
{
    //Initialise properties
    [SerializeField]
    CardScriptableObject[] totalCards;
    public CardScriptableObject[] TotalCards { get => totalCards; private set => totalCards = value; }

    [SerializeField]
    CardScriptableObject[] hand;
    public CardScriptableObject[] Hand { get => hand; private set => hand = value; }

    [SerializeField]
    CardScriptableObject[] discardPile;
    public CardScriptableObject[] DiscardPile { get => discardPile; private set => discardPile = value; }

    //A simple shuffle method, which just swaps cards around randomly then returns the shuffled deck
    public CardScriptableObject[] Shuffle()
    {
        CardScriptableObject[] shuffledDeck = (CardScriptableObject[])totalCards.Clone();
        for (int i = 0; i < shuffledDeck.Length; i++)
        {
            CardScriptableObject temp = shuffledDeck[i];
            int randomIndex = Random.Range(i, shuffledDeck.Length);
            shuffledDeck[i] = shuffledDeck[randomIndex];
            shuffledDeck[randomIndex] = temp;
        }

        //Draw 5 cards into hand

        for (int i = 0; i < 5; i++)
        {
            Debug.Log(shuffledDeck[i].CardName);
            hand[i] = (shuffledDeck[i]);
        }

        // The rest go into the discard pile

        for (int i = 5; i < shuffledDeck.Length; i++)
        {
            discardPile[i - 5] = (shuffledDeck[i]);
        }

        return shuffledDeck;
    }

}
