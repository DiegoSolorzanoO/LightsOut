using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public int id;
    public string iName;
    public string iDescription;
    public IType iType;
    
    public enum IType {
        Weapon,
        Consumable,
        Tool
    }

    public int GetID() {
        return id;
    }
}
