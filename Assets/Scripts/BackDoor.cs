using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackDoor : MonoBehaviour
{
    public int IdKey;
    public string goTo;
    public int doorId;

    private TextBoxController tb;

    private void Awake() {
        tb = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TextBoxController>();
    }

    public void Interact(GameObject player) {
        InventoryController inv = player.gameObject.GetComponent<InventoryController>();
        if (WorldVariables.doors[doorId]) {
            SceneManager.LoadScene(goTo);
        } else if (!WorldVariables.doors[doorId] && inv.HasItem(IdKey)) {
            inv.RemoveItem(IdKey);
            WorldVariables.doors[doorId] = true;
            SceneManager.LoadScene(goTo);
        } else {
            tb.ChangeText("Locked door...");
        }
    }
}
