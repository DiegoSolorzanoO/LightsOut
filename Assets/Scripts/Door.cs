using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public int IdKey;
    public bool unlocked;
    public bool opened;

    private Animator animator;
    private TextBoxController tb;
    private BoxCollider2D bc;

    private void Awake() {
        opened = false;
        animator = GetComponent<Animator>();
        tb = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextBoxController>();
        bc = GetComponent<BoxCollider2D>();
    }

    public void Interact(GameObject player) {
        InventoryController inv = player.gameObject.GetComponent<InventoryController>();
        if (unlocked && !opened) {
            ChangeState();
        } else if (!unlocked && inv.HasItem(IdKey)) {
            inv.RemoveItem(IdKey);
            unlocked = true;
            ChangeState();
        } else if (opened) {
            ChangeState();
        } else {
            tb.ChangeText("Locked door. I need a key...");
        }
    }

    private void ChangeState() {
        if (opened) {
            animator.SetInteger("AnimState", 0);
            bc.offset = new Vector2(-1, 40);
            bc.size = new Vector2(9, 80);
        } else {
            animator.SetInteger("AnimState", 1);
            bc.offset = new Vector2(-1, 80);
            bc.size = new Vector2(9, 10);
        }
        opened = !opened;
    }

    /*private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Debug.Log("DoorTouching");
            Inventory inv = collision.gameObject.GetComponent<Inventory>();
            if(Input.GetKeyDown(KeyCode.E)) {
                if (inv.HasItem(IdKey)) {
                    inv.RemoveItem(IdKey);
                    animator.SetInteger("AnimState", 1);
                    Destroy(gameObject.GetComponent<BoxCollider2D>());
                } else {
                    tb.ChangeText("Locked door. I need a key...");
                }
            }
        }
    }*/
}
