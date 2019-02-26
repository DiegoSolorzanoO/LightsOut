using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerState ps;
    private Inventory inv;
    private TextBoxController tbc;

    private void Awake() {
        ps = GetComponent<PlayerState>();
        inv = GetComponent<Inventory>();
        tbc = GetComponent<TextBoxController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        tbc.ChangeText("Presiona E para interactuar");
    }

    private void OnTriggerExit2D(Collider2D collision) {
        tbc.ClearText();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (collision.gameObject.tag == "Item") {
                inv.AddItem(collision.gameObject.name);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.tag == "Interactable") {
                Interactable sc = collision.gameObject.GetComponent<Interactable>();
                if (ps.Interact()) {
                    inv.AddItem(sc.GetItem());
                    sc.CanInteract(false);
                }
            }
        }
    }
}
