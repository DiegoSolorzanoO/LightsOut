using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONFactory;

public class PanelManager : MonoBehaviour {

    public GameObject panel;

    private PanelConfig panelConfig;
    private int stepIndex = 0;
    private NarrativeEvent currentEvent;

    private void Awake() {
        panelConfig = panel.GetComponent<PanelConfig>();
        panel.SetActive(false);
    }

    private void Start() {
        //WorldVariables.StartDialogue(1);
    }

    private void Update() {
        if (WorldVariables.initilizeDialogue) {
            WorldVariables.initilizeDialogue = false;
            stepIndex = 0;
            panel.SetActive(true);
            currentEvent = JSONAssembly.RunJSONFactoryForScene(WorldVariables.sceneN);
            InitializePanels();
        } else if (Input.GetKeyDown(KeyCode.Space) && WorldVariables.dialogueActive) {
            NextPanelState();
        }
    }

    private void NextPanelState() {
        if (stepIndex<currentEvent.dialogues.Count) {
            panelConfig.SendDialogue(currentEvent.dialogues[stepIndex]);
            stepIndex++;
        } else {
            panel.SetActive(false);
            WorldVariables.dialogueActive = false;
        }
    }

    private void InitializePanels() {
        panelConfig.characterIsTalking = true;
        panelConfig.SendDialogue(currentEvent.dialogues[stepIndex]);
        stepIndex++;
    }


}
