using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DeckScriptableObject", menuName = "ScriptableObjects/DeckScriptableObject")]
public class DeckScriptableObject : ScriptableObject
{
    //Initialise properties
    [SerializeField]
    CardScriptableObject[] totalCards;
    public CardScriptableObject[] TotalCards { get => totalCards; private set => totalCards = value; }
}
