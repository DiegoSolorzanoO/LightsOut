using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MasterManager {

    public static Sprite GetSprite(string spriteName) {
        Sprite[] sprites;
        sprites = Resources.LoadAll<Sprite>("Characters");
        foreach( Sprite sprite in sprites) {
            if (sprite.name.Equals(spriteName)) {
                return sprite;
            }
        }
        throw new Exception("No se encontró el sprite.");
    }

}
