using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room7Manager : MonoBehaviour
{
    private GameObject player;

    private void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start() {
        player.transform.position = new Vector3(-121, -72, 0);
        player.GetComponent<PlayerState>().direction = 1;
        WorldVariables.level1Position = 7;
    }
}
