using UnityEngine;
using TMPro;

public class UnitUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text staggerText;

    private UnitInstance unit;

    public BattleManager battleManager;
    public HandUIManager handUIManager;
    public void Initialise(UnitInstance unitInstance)
    {
        unit = unitInstance;

        battleManager = FindFirstObjectByType<BattleManager>();
        handUIManager = FindFirstObjectByType<HandUIManager>();

        nameText.text = unit.unitName;
        healthText.text = "Health: " + unit.currentHealth + "/" + unit.maxHealth;
    }


    private void Update()
    {
        Raycast2D();
    }

    private void Raycast2D()
    {
        //if left click
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // get the mouse position using the camera

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero); //make a raycast to see what its hitting

            if (hit.collider != null) //if it hits something
            {
                Debug.Log(hit.collider.gameObject.transform.parent); //debugging purposes
                if (hit.collider.transform.IsChildOf(transform)) //if it hits the gameobject that this script is on
                {
                    battleManager.currentlySelected = true;
                    handUIManager.DisplayHand(this.gameObject.GetComponent<UnitBehaviour>().Instance.Deck.Hand);
                    Debug.Log("hit this col");
                }
                else
                {
                    battleManager.currentlySelected = false;
                }
            }
        }
    }

}
