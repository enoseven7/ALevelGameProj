using UnityEngine;

public class UnitInstance
{
    public UnitScriptableObject baseData;

    public string name { get; private set; }
    public float currentHealth { get; private set; }
    public float currentStagger { get; private set; }
    public bool Alive => currentHealth > 0;

    public DeckInstance Deck { get; private set; }

    public UnitInstance(UnitScriptableObject baseData)
    {
        this.baseData = baseData;

        name = baseData.name;
        currentHealth = baseData.Health;
        currentStagger = baseData.Stagger;

        Deck = new DeckInstance(baseData.Deck);
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if (currentHealth < 0) 
            currentHealth = 0;
    }
}
