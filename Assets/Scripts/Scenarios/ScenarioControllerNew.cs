using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioControllerNew : MonoBehaviour {

    public DomoticaController domoticsController;
    public UIHandlerNew UIHandler;
    public Player player;
    public GameState gameState;
    public ScenarioNew editorScenario;

    // Start is called before the first frame update
    void Start() {
        player.disablePlayerControls();
        editorScenario.initialize();
        UIHandler.displayIntro(editorScenario.getTitle(), editorScenario.getIntro().getFirstLine(), editorScenario.getIntro().getSecondLine());
        UIHandler.setNewObjective(editorScenario.getCurrentStepObjective());
    }

    // Update is called once per frame
    void Update() {
        if (editorScenario.stepCompleted() && editorScenario.hasNextStep()) {
            editorScenario.nextStep();
            UIHandler.setNewObjective(editorScenario.getCurrentStepObjective());
        } else if (editorScenario.stepCompleted()) {
            player.disablePlayerControls();
            UIHandler.displayOutro("outro", "bye", "lol");
        }
    }

}