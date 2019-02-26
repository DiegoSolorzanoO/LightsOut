using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDuck : MonoBehaviour
{
    private PlayerState ps;
    private CapsuleCollider2D cc;
         
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<PlayerState>();
        cc = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.S) && !ps.Running() && ps.CanMove()) {
            cc.direction = CapsuleDirection2D.Horizontal;
            cc.size = new Vector2(43,10);
            cc.offset = new Vector2(0, 6);
            ps.Ducking(true);
        } else {
            cc.direction = CapsuleDirection2D.Vertical;
            cc.size = new Vector2(29, 59);
            cc.offset = new Vector2(0, 29.5f);
            ps.Ducking(false);
        }
    }
}
