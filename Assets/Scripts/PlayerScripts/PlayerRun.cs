﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
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
        if (Input.GetKey(KeyCode.LeftShift) && !ps.ducking && ps.canMove) {
            ps.running = true;
            return;
        } else {
            ps.running = false;
        }
    }
}
