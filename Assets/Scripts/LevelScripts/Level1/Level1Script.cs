using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Script : MonoBehaviour
{
    private Transform playerT;

    public Vector3 room5Pos;
    public Vector3 room4Pos;
    public Vector3 room7Pos;
    public Vector3 room8Pos;
    public Vector3 room6Pos;
    public Vector3 electricity;
    public Vector3 stairs;

    private void Awake() {
        playerT = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Start()
    {
        if (WorldVariables.level1Start) {
            WorldVariables.StartDialogue(1);
            WorldVariables.level1Start = false;
        }
        if(WorldVariables.level1Position == 5) {
            playerT.position = room5Pos;
        } else if(WorldVariables.level1Position == 4){
            playerT.position = room4Pos;
        } else if (WorldVariables.level1Position == 7) {
            playerT.position = room7Pos;
        } else if (WorldVariables.level1Position == 8) {
            playerT.position = room8Pos;
        } else if (WorldVariables.level1Position == 6) {
            playerT.position = room6Pos;
        } else if (WorldVariables.level1Position == 0) {
            playerT.position = electricity;
        } else if (WorldVariables.level1Position == 1) {
            playerT.position = stairs;
        }
    }

    void Update()
    {
        
    }
}
