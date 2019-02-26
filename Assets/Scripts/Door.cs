using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    public int IdKey;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            Inventory inv = collision.gameObject.GetComponent<Inventory>();
            if(Input.GetKeyDown(KeyCode.E)) {
                if (inv.HasItem(IdKey)) {
                    inv.RemoveItem(IdKey);
                    animator.SetInteger("AnimState", 1);
                    Destroy(gameObject.GetComponent<BoxCollider2D>());
                }
            }
        }
    }
}
