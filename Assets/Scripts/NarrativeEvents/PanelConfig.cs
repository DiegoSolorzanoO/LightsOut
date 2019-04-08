using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PanelConfig : MonoBehaviour
{
    public bool characterIsTalking;
    public Image avatarImage;
    public Text characterName;
    public Text dialogue;

    public void SendDialogue(Dialogue currentDialogue) {
        avatarImage.sprite = GetSprite(currentDialogue.image);
        characterName.text = currentDialogue.name;

        if (characterIsTalking) {
            StopAllCoroutines();
            StartCoroutine(AnimateText(currentDialogue.dialogueText));
        } else {
            dialogue.text = "";
        }
    }

    IEnumerator AnimateText(string dialogueText) {
        dialogue.text = "";
        foreach(char letter in dialogueText) {
            dialogue.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public static Sprite GetSprite(string spriteName) {
        Sprite[] sprites;
        sprites = Resources.LoadAll<Sprite>("Characters");
        foreach (Sprite sprite in sprites) {
            if (sprite.name.Equals(spriteName)) {
                return sprite;
            }
        }
        throw new Exception("No se encontró el sprite.");
    }
}
