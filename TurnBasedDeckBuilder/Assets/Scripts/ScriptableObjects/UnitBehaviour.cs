using UnityEngine;

public class UnitBehaviour : MonoBehaviour
{
    public UnitInstance Instance { get; private set; }

    public void Init(UnitInstance instance)
    {
        Instance = instance;
    }
}
