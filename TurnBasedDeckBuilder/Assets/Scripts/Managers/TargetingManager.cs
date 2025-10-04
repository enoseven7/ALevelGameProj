using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class TargetingManager : MonoBehaviour
{
    public static TargetingManager Instance;

    private List<LineRenderer> activeLines = new List<LineRenderer>();
    public LineRenderer linePrefab;

    private void Awake()
    {
        Instance = this;
    }

    public void AssignTarget(CardDrag card, SpeedDiceSlotUI slot)
    {
        UnitBehaviour sourceUnit = card.GetComponentInParent<UnitBehaviour>();
        UnitBehaviour targetUnit = slot.GetComponentInParent<UnitBehaviour>();

        if (sourceUnit != null && targetUnit != null)
        {
            LineRenderer line = Instantiate(linePrefab, transform);
            line.positionCount = 2;
            line.SetPosition(0, sourceUnit.transform.position);
            line.SetPosition(1, targetUnit.transform.position);

            activeLines.Add(line);
            Debug.Log("Line added");
        }
    }
}
