﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeEvent
{
    public List<Dialogue> dialogues;
}

public struct Dialogue {
    public CharacterType characterType;
    public string name;
    public string image;
    public string dialogueText;
}

public enum CharacterType {
    Player, Shadow
}
