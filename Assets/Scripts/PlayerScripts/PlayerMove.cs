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
        if(Input.GetKey(KeyCode.A) && ps.canMove) {
            transform.Translate(-5*ps.speed*Time.deltaTime,0,0);
            ps.moving = true;
            ps.direction = 0;
            return;
        }
        if (Input.GetKey(KeyCode.D) && ps.canMove) {
            transform.Translate(5 * ps.speed * Time.deltaTime, 0, 0);
            ps.moving = true;
            ps.direction = 1;
            return;
        }
        ps.moving = false;
    }
}
