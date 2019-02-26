using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv = new List<Item>();
    public GUIStyle invStyle;

    private ItemDatabase db;

    private void Awake() {
        db = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();
        
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
                inv.Add(item);
            }
        }
    }

    public bool RemoveItem(int sid) {
        foreach (Item item in inv) {
            if (item.id == sid) {
                inv.Remove(item);
                return true;
            }
        }
        return false;
    }

    public bool HasItem(int sid) {
        foreach (Item item in inv) {
            if (item.id == sid) {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (Input.GetKeyDown(KeyCode.E)) {
            if (collision.gameObject.tag == "Item") {
                AddItem(collision.gameObject.name);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnGUI() {
        for(int i = 0; i < inv.Count; i++) {
            GUI.TextField(new Rect(i * 100, 30, 200, 50), inv[i].iName, invStyle);
        }
    }
}
