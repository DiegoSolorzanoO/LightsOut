using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxController : MonoBehaviour
{
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearText() {
        textBox.text = "";
    }

    public void ChangeText(string ntext) {
        textBox.text = ntext;
    }

    public void Warning(string ntext) {
        textBox.text = ntext;
        StartCoroutine(WarningTime());
    }

    IEnumerator WarningTime() {
        yield return new WaitForSeconds(3);
        textBox.text = "";
    }
}
