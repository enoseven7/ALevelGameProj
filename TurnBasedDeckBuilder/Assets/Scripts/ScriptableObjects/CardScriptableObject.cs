using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CardScriptableObject", menuName = "ScriptableObjects/CardScriptableObject")]
public class CardScriptableObject : ScriptableObject
{
    [SerializeField]
    AtkDiceScriptableObject[] atkDice;
    public AtkDiceScriptableObject[] AtkDice { get => atkDice; private set => atkDice = value; }

    [SerializeField]
    int energyCost;
    public int EnergyCost { get => energyCost; private set => energyCost = value; }

    [SerializeField]
    Sprite cardImg;
    public Sprite CardImg { get => cardImg; private set => cardImg = value; }

    [SerializeField]
    string cardName;
    public string CardName { get => cardName; private set => cardName = value; }

}
