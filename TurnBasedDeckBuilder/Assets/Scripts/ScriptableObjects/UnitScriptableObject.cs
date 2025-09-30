using UnityEngine;

[CreateAssetMenu(fileName = "UnitScriptableObject", menuName = "ScriptableObjects/UnitScriptableObject")]
public class UnitScriptableObject : ScriptableObject
{
    public enum ResistanceValues
    {
        Ineffective, //x0.25
        Endured, //0.5x
        Normal, //x1
        Weak, //x1.5
        Fatal //x2
    }

    [SerializeField]
    string unitName;
    public string Name { get => name; set => name = value; }

    [SerializeField]
    float stagger;
    public float Stagger { get => stagger; set => stagger = value; }

    [SerializeField]
    float health;
    public float Health { get => health; set => health = value; }

    [SerializeField]
    ResistanceValues bluntHealth;
    public ResistanceValues BountHealth { get => bluntHealth; set => bluntHealth = value; }

    [SerializeField]
    ResistanceValues bluntStagger;
    public ResistanceValues BountStagger { get => bluntStagger; set => bluntStagger = value; }

    [SerializeField]
    ResistanceValues slashHealth;
    public ResistanceValues SlashHealth { get => slashHealth; set => slashHealth = value; }

    [SerializeField]
    ResistanceValues slashStagger;
    public ResistanceValues SlashStagger { get => slashStagger; set => slashStagger = value; }

    [SerializeField]
    ResistanceValues pierceHealth;
    public ResistanceValues PierceHealth { get => pierceHealth; set => pierceHealth = value; }

    [SerializeField]
    ResistanceValues pierceStagger;
    public ResistanceValues PierceStagger { get => pierceStagger; set => pierceStagger = value; }

    [SerializeField]
    bool alive;
    public bool Alive { get => alive; set => alive = value; }
}
