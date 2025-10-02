using UnityEngine;

public class UnitInstance : MonoBehaviour
{
    public UnitScriptableObject baseData;

    public string unitName { get; private set; }
    public float currentHealth { get; private set; }

    public float maxHealth { get; private set; }
    public float currentStagger { get; private set; }

    public float maxStagger { get; private set; }
    public bool Alive => currentHealth > 0;

    public bool player {  get; private set; }

    public DeckInstance Deck { get; private set; }

    public UnitInstance(UnitScriptableObject baseData)
    {
        this.baseData = baseData;

        unitName = baseData.UnitName;
        currentHealth = baseData.Health;
        maxHealth = baseData.Health;
        currentStagger = baseData.Stagger;
        maxStagger = baseData.Stagger;
        player = baseData.Player;

        Deck = new DeckInstance(baseData.Deck);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0) 
            currentHealth = 0;
    }
}
