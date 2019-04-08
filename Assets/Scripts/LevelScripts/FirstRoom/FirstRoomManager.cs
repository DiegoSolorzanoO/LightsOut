using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstRoomManager : MonoBehaviour
{
    private GameObject playerGO;

    private void Awake() {
        playerGO = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        if (WorldVariables.firstRoomStart) {
            playerGO.transform.position = new Vector3(90, -72, 0);
            WorldVariables.firstRoomStart = false;

            WorldVariables.StartDialogue(0);
        } else {
            playerGO.transform.position = new Vector3(-120, -72, 0);
            playerGO.GetComponent<PlayerState>().direction = 1;
        }
        WorldVariables.level1Position = 5;
    }
}
