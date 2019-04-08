using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private PlayerState ps;
    private InventoryController inv;
    private TextBoxController tbc;
    private RaycastHit2D hit2D;

    private void Awake() {
        ps = GetComponent<PlayerState>();
        inv = GetComponent<InventoryController>();
        tbc = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextBoxController>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update() {
        hit2D = Physics2D.Raycast(new Vector2(transform.position.x-15,transform.position.y+5), Vector2.right, 30f);
        if (hit2D && Input.GetKeyDown(KeyCode.E) && !WorldVariables.dialogueActive) {
                if (hit2D.collider.gameObject.tag == "Door") {
                    Door door = hit2D.collider.gameObject.GetComponent<Door>();
                    door.Interact(this.gameObject);
                } else if (hit2D.collider.gameObject.tag == "Interactable") {
                    Interactable inter = hit2D.collider.gameObject.GetComponent<Interactable>();
                    if (ps.Interact()) {
                        inv.AddItem(inter.GetItem());
                        inter.CanInteract(false);
                    }
                } else if (hit2D.collider.gameObject.tag == "Item") {
                    FreeItem item = hit2D.collider.gameObject.GetComponent<FreeItem>();
                    inv.AddItem(item.id);
                    Destroy(hit2D.collider.gameObject);
                } else if (hit2D.collider.gameObject.tag == "BackDoor") {
                    BackDoor door = hit2D.collider.gameObject.GetComponent<BackDoor>();
                    door.Interact(this.gameObject);
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (!(collision.gameObject.tag == "EventTrigger")) {
            tbc.ChangeText("Press E to interact");
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        tbc.ClearText();
    }

    /*private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("Collision Activated");
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
    }*/
}
