using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
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
        if(Input.GetKey(KeyCode.A) && ps.CanMove()) {
            transform.Translate(-5*ps.GetSpeed()*Time.deltaTime,0,0);
            ps.Moving(true);
            return;
        }
        if (Input.GetKey(KeyCode.D) && ps.CanMove()) {
            transform.Translate(5 * ps.GetSpeed() * Time.deltaTime, 0, 0);
            ps.Moving(true);
            return;
        }
        ps.Moving(false);
    }
}
