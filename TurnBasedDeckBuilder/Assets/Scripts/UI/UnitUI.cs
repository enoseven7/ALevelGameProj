using UnityEngine;
using TMPro;

public class UnitUI : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text healthText;
    public TMP_Text staggerText;

    private UnitInstance unit;

    [SerializeField] Collider2D col;

    [SerializeField] bool currentlySelected = false;
    public void Initialise(UnitInstance unitInstance)
    {
        unit = unitInstance;

        

        nameText.text = unit.name;
        healthText.text = "Health: " + unit.currentHealth + "/" + unit.maxHealth;
    }

    private void Start()
    {
        col = FindFirstObjectByType<Collider2D>();
    }

    private void Update()
    {
        Raycast2D();
    }

    private void Raycast2D()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.transform.parent);
                if (hit.collider.transform.IsChildOf(transform))
                {
                    currentlySelected = true;
                    Debug.Log("hit this col");
                }
                else
                {
                    currentlySelected = false;
                }
            }
        }
    }

    private void OnGUI()
    {
        if (currentlySelected)
        {
            GUI.Label(new Rect(10, 10, 200, 20), "Currently Selected: " + nameText.text);
        }
    }
}
