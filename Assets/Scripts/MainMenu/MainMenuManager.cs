using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject golight;
    public GameObject panel;
    public Text textO;
    public GameObject pS;

    private bool canSpace;
    private string textString;
    private new Light light;
    private Coroutine lighttickC;

    private void Awake() {
        light = golight.GetComponent<Light>();
        panel.SetActive(false);
        textString = textO.text;
        textO.text = "";
        canSpace = false;
        pS.SetActive(false);
    }

    private void Start() {
        lighttickC = StartCoroutine(Lighttick());
        
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && canSpace) {
            WorldVariables.firstRoomStart = true;
            SceneManager.LoadScene("FirstRoom");
        }
    }

    public void ChangeScene() {
        StartCoroutine(StartGame());
    }

    public void Exit() {
        Application.Quit();
    }

    IEnumerator StartGame() {
        StopCoroutine(lighttickC);
        canvas.SetActive(false);
        yield return new WaitForSeconds(1);
        while (light.range > 0) {
            light.range -= 3;
            yield return new WaitForSeconds(0.1f);
        }
        panel.SetActive(true);
        textO.text = "";
        foreach (char letter in textString) {
            textO.text += letter;
            yield return new WaitForSeconds(0.07f);
        }
        canSpace = true;
        yield return new WaitForSeconds(1);
        pS.SetActive(true);
    }

    IEnumerator Lighttick() {
        while (true) {
            light.range = Random.Range(100, 400);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
