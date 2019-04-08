using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventShooterS : MonoBehaviour
{

    public int eventNumber;
    public bool givesItem = false;
    public int itemId;

    private InventoryController playerInv;

    private void Awake() {
        playerInv = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (WorldVariables.eventos[eventNumber]) {
            WorldVariables.eventos[eventNumber] = false;
            WorldVariables.StartDialogue(eventNumber);
        }
    }

    private void Update() {
        if (!WorldVariables.dialogueActive && !WorldVariables.eventos[eventNumber] && WorldVariables.items[itemId]) {
            if (givesItem) {
                playerInv.AddItem(itemId);
            }
            WorldVariables.items[itemId] = false;
        }
    }
}
