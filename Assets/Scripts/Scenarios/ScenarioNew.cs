using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioNew : MonoBehaviour {

    public Transform startLocation;
    public string title;
    public Introduction intro;
    public Introduction outro;
    public List<Step> steps;
    public bool startWithOpenCurtains;
    public bool startWithLightsOn;
    public DayNightManager.DayPart timeOfDay;

    private int activeStepIndex = 0;
    private Step currentStep;

    public void initialize(){
        applyDomoticsControllerSettings();
        applyStartingPositionToPlayer();
        setTimeOfDay();
        this.currentStep = steps[0];
    }

    private void setTimeOfDay(){
        GameObject.FindObjectOfType<DayNightManager>().SetDayPart(timeOfDay);
    }

    private void applyDomoticsControllerSettings(){
        DomoticaController domoticsController = GameObject.FindObjectOfType<DomoticaController>();
        domoticsController.SwitchCurtainsWithoutAnimation(startWithOpenCurtains);
        domoticsController.SwitchLights(startWithLightsOn);
    }

    private void applyStartingPositionToPlayer(){
        GameObject player = FindObjectOfType<EditorPlayer>().gameObject;
        player.transform.SetPositionAndRotation(startLocation.transform.position, startLocation.transform.rotation);
    }

    public Introduction getIntro(){
        return this.intro;
    }

    public string getTitle(){
        return this.title;
    }

    public bool hasNextStep(){
        return activeStepIndex + 1 < steps.Count;
    }

    public void nextStep(){
        activeStepIndex++;
        currentStep = steps[activeStepIndex];
        currentStep.Run();
    }

    public string getCurrentStepObjective(){
        return this.currentStep.GetStepName();
    }

    public bool stepCompleted(){
        return currentStep && currentStep.getState() == State.COMPLETED;
    }
}
