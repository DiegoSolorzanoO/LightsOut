using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject canvas;

    private void Awake() {
        WorldVariables.paused = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P))
            WorldVariables.paused = TogglePause();
    }

    public bool IsPaused() {
        return WorldVariables.paused;
    }

    private void OnGUI() {
        if (!WorldVariables.paused) {
            canvas.SetActive(false);
            return;
        }
        canvas.SetActive(true);
    }

    public void ChangePause() {
        WorldVariables.paused = TogglePause();
    }

    public void quitGame() {
        Application.Quit();
    }

    bool TogglePause() {
        if (Time.timeScale == 0f) {
            Time.timeScale = 1f;
            return (false);
        } else {
            Time.timeScale = 0f;
            return (true);
        }
    }
}
