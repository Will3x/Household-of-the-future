using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandlerNew : MonoBehaviour {

    public UnityEngine.UI.Text scenarioTitleText;
    public UnityEngine.UI.Text firstLineText;
    public UnityEngine.UI.Text secondLineText;
    public UnityEngine.UI.Text stepObjectiveText;
    public UnityEngine.UI.Text ButtonText;
    public GameObject infoCanvas;
    public GameObject objectiveCanvas;

    public void displayIntro(string title, string firstLineText, string secondLineText) {
        setButtonText("Start scenario");
        setInfoPanel(title, firstLineText, secondLineText);
        infoCanvas.SetActive(true);
        StartCoroutine(startFadeInAnimation());
    }

    public void displayOutro(string title, string firstLineText, string secondLineText) {
        setButtonText("Ga door");
        setInfoPanel(title, firstLineText, secondLineText);
        infoCanvas.SetActive(true);
    }

    private void setInfoPanel(string title, string firstLineText, string secondLineText) {
        setTitle(title);
        setFirstLine(firstLineText);
        setSecondLine(secondLineText);
    }

    IEnumerator startFadeInAnimation() {
        for (float i = 0; i <= 5; i += Time.deltaTime) {
            yield return null;
        }

        for (float i = 0; i <= 5; i += Time.deltaTime) {
            scenarioTitleText.color = new Color(1, 1, 1, i);
            yield return null;
        }

        for (float i = 0; i <= 5; i += Time.deltaTime) {
            firstLineText.color = new Color(1, 1, 1, i);
            yield return null;
        }

        for (float i = 0; i <= 5; i += Time.deltaTime) {
            secondLineText.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    private void setTitle(string title) {
        this.scenarioTitleText.text = title;
    }

    private void setFirstLine(string firstLine) {
        this.firstLineText.text = firstLine;
    }

    private void setSecondLine(string secondLine) {
        this.secondLineText.text = secondLine;
    }

    private void setButtonText(string buttonText) {
        this.ButtonText.text = buttonText;
    }

    public void setNewObjective(string newObjective) {
        this.stepObjectiveText.text = newObjective;
    }
}