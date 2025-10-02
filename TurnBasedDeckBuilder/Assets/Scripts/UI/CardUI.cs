using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private Image[] diceImages; 

    public void SetCard(CardScriptableObject cardData, Sprite placeholder = null)
    {
        if (cardData == null)
        {
            gameObject.SetActive(false);
            return;
        }

        nameText.text = cardData.CardName;

        // reset dice slots
        for (int i = 0; i < diceImages.Length; i++)
        {
            diceImages[i].sprite = placeholder;
            diceImages[i].enabled = false;
        }

        // apply the dice this card actually has
        for (int i = 0; i < cardData.AtkDice.Length; i++)
        {
            diceImages[i].sprite = cardData.AtkDiceSprites[i];
            diceImages[i].enabled = true;
        }

        gameObject.SetActive(true);
    }
}
