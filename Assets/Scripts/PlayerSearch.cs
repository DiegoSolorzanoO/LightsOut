using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSearch : MonoBehaviour
{
    private PlayerState ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerState>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.P) && !ps.Moving() && !ps.Ducking()) {
            ps.CanMove(false);
            ps.Interacting(true);
            StartCoroutine(Searching());
            
        }
    }

    IEnumerator Searching() {
        yield return new WaitForSeconds(3);
        ps.CanMove(true);
        ps.Interacting(false);
    }
}
