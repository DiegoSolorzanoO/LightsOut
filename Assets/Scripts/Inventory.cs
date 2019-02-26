using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> inv = new List<Item>();
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
                inv.Add(item);
            }
        }
    }
    public void AddItem(int sid) {
        foreach (Item item in db.items) {
            if (item.id == sid) {
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
            if (collision.gameObject.tag == "Interactable") {
                Interactable sc = collision.gameObject.GetComponent<Interactable>();
                if(ps.Interact()) {
                    AddItem(sc.GetItem());
                    sc.CanInteract(false);
                }
            }
        }
    }

    private void OnGUI() {
        for(int i = 0; i < inv.Count; i++) {
            GUI.TextField(new Rect(100 + i * 50, 30, 50, 50), "", invStyle);
            GUI.DrawTexture(new Rect(100+ i * 50, 30, 50, 50), inv[i].icon);
            
        }
    }
}
