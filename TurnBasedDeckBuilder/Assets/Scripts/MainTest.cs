using UnityEngine;

public class MainTest : MonoBehaviour
{
    public DeckScriptableObject testDeck;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        testDeck.Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
