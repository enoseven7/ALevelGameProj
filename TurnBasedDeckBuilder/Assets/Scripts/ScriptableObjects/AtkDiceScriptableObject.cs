using UnityEngine;

[CreateAssetMenu(fileName = "AtkDiceScriptableObject", menuName = "ScriptableObjects/AtkDiceScriptableObject")]
public class AtkDiceScriptableObject : ScriptableObject
{
    // Using an enumerator for different but specific types of attacks
    public enum AttackType
    {
        Blunt,
        Pierce,
        Slash,
        Block,
        Evade,
        Counter
    }

    // Using an enumerator for different but specific types of status effects
    public enum StatusEffects
    {
        Burn,
        Bleed,
        Poise,
        Charge,
        Bind,
        Haste,
        Protection,
        Strength,
        Fragile,
        None
    }

    // Creating the variables for the attack dice, having a private version where the value is stored and a public version where the value can be accessed but not changed

    [SerializeField]
    AttackType atkType;
    public AttackType AtkType  { get => atkType; private set => atkType = value; }

    [SerializeField]
    StatusEffects status;
    public StatusEffects Status { get => status; private set => status = value; }

    [SerializeField]
    int statusCount;
    public int StatusCount { get => statusCount; private set => statusCount = value; }

    [SerializeField]
    int minRoll;
    public int MinRoll { get => minRoll; private set => minRoll = value; }

    [SerializeField]
    int maxRoll;
    public int MaxRoll { get => maxRoll; private set => maxRoll = value; }
}
