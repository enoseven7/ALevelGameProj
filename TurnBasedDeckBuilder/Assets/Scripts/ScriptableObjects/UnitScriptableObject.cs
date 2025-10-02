using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnitScriptableObject;

[CreateAssetMenu(fileName = "UnitScriptableObject", menuName = "ScriptableObjects/UnitScriptableObject")]
public class UnitScriptableObject : ScriptableObject
{
    public enum ResistanceValue
    {
        Ineffective, //x0.25
        Endured, //0.5x
        Normal, //x1
        Weak, //x1.5
        Fatal //x2
    }

    public enum DamageType
    {
        Slash,
        Pierce,
        Blunt
    }

    public enum ResistanceType
    {
        Health,
        Stagger
    }

    [SerializeField]
    string unitName;
    public string UnitName { get => name; set => name = value; }

    [SerializeField]
    float stagger;
    public float Stagger { get => stagger; set => stagger = value; }

    [SerializeField]
    float health;
    public float Health { get => health; set => health = value; }

    [System.Serializable]
    public struct ResistanceEntry
    {
        public DamageType damageType;
        public ResistanceType resistanceType;
        public ResistanceValue value;
    }

    [SerializeField] private List<ResistanceEntry> resistances;

    private Dictionary<(DamageType, ResistanceType), ResistanceValue> resistanceDict;

    private void OnEnable()
    {
        resistanceDict = new Dictionary<(DamageType, ResistanceType), ResistanceValue>();
        foreach (var res in resistances)
        {
            resistanceDict[(res.damageType, res.resistanceType)] = res.value;
        }
    }

    public ResistanceValue GetResistance(DamageType dmg, ResistanceType resType)
    {
        if (resistanceDict.TryGetValue((dmg, resType), out var value))
            return value;

        return ResistanceValue.Normal; // default
    }

    [System.Serializable]
    public struct SpeedDice
    {
        public int minRoll;
        public int maxRoll;
        public bool enabledAtStart;
    }

    [SerializeField] private List<SpeedDice> speedDiceList;

    [SerializeField] private DeckScriptableObject deck;
    public DeckScriptableObject Deck {  get => deck; set => deck = value; }

    [SerializeField]
    private bool player;
    public bool Player { get => player; set => player = value; }

}
