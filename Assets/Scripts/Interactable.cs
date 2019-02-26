using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool canInteract;
    public int itemId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetItem() {
        if(canInteract) {
            return itemId;
        }
        return -1;
    }

    public void CanInteract(bool nvalue) {
        canInteract = nvalue;
    }

}
