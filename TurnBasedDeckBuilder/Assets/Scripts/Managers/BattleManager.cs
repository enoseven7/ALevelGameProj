using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    [SerializeField] private GameObject unitPrefab;
    [SerializeField] private Transform unitContainer;

    [SerializeField] private List<UnitScriptableObject> unitsToSpawn;

    private List<UnitInstance> unitInstances = new List<UnitInstance>();
    private List<GameObject> unitGameObjects = new List<GameObject>();

    [SerializeField] private List<Transform> playerSpawnLocations;
    [SerializeField] private List<Transform> enemySpawnLocations;

    public List<GameObject> cardUIs = new List<GameObject>();

    public bool currentlySelected = false;

    public Sprite placeholderSprite;

    void Start()
    {
        SpawnUnits();
    }

    private void SpawnUnits()
    {
        int playerI = 0;
        int enemyI = 0;
        foreach (var unitSO in unitsToSpawn)
        {
            // create the runtime instance
            UnitInstance unitInstance = new UnitInstance(unitSO);
            unitInstances.Add(unitInstance);

            // spawn the prefab in the scene
            GameObject unitGO = Instantiate(unitPrefab, unitContainer);
            UnitBehaviour behaviour = unitGO.GetComponent<UnitBehaviour>();
            behaviour.Init(unitInstance);

            unitGO.name = unitInstance.unitName; // set object name for clarity

            if(unitInstance.player)
            {
                unitGO.transform.position = playerSpawnLocations[playerI].transform.position;
                playerI++;
            }
            else
            {
                unitGO.transform.position = enemySpawnLocations[enemyI].transform.position;
                enemyI++;
            }

                // hook up to unitUI
                UnitUI ui = unitGO.GetComponent<UnitUI>();
            if (ui != null)
                ui.Initialise(unitInstance); // pass the runtime instance

            unitGameObjects.Add(unitGO);
            
        }
    }

}
