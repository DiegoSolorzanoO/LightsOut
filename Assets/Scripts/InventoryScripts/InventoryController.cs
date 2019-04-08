using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GUIStyle invStyle;
    private PlayerState ps;

    private ItemDatabase db;

    private void Awake() {
        db = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        ps = GetComponent<PlayerState>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddItem(string name) {
        foreach (Item item in db.items) {
            if (item.iName.Equals(name)) {
                Inventory.items.Add(item);
            }
        }
    }
    public void AddItem(int sid) {
        foreach (Item item in db.items) {
            if (item.id == sid) {
                Inventory.items.Add(item);
            }
        }
    }

    public bool RemoveItem(int sid) {
        foreach (Item item in Inventory.items) {
            if (item.id == sid) {
                Inventory.items.Remove(item);
                return true;
            }
        }
        return false;
    }

    public bool HasItem(int sid) {
        foreach (Item item in Inventory.items) {
            if (item.id == sid) {
                return true;
            }
        }
        return false;
    }

    private void OnGUI() {
        if (!WorldVariables.paused) {
            GUI.Label(new Rect(Screen.width * 0.05f, Screen.height * 0.05f, Screen.width * 0.06f * 5, Screen.height * 0.10f), "", invStyle);
            for (int i = 0; i < Inventory.items.Count; i++) {
                GUI.DrawTexture(new Rect(Screen.width * 0.05f + i * Screen.width * 0.06f, Screen.height * 0.05f, Screen.width * 0.06f, Screen.height * 0.10f), Inventory.items[i].icon);
            }
        }
    }
}
