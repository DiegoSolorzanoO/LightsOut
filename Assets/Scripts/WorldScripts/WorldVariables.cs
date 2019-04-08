using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldVariables
{
    public static bool paused;
    public static bool dialogueActive;
    public static bool initilizeDialogue;
    public static int sceneN;

    public static bool firstRoomStart;
    public static bool level1Start = true;
    public static bool[] eventos = {false,false,true,true};
    public static bool[] items = { true, true };
    public static bool[] doors = { true, false };

    public static int level1Position;

    public static void StartDialogue(int sceneNum) {
        dialogueActive = true;
        initilizeDialogue = true;
        sceneN = sceneNum;

    }
}
