using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Use on a trigger object to make it active a Step
/// @Version: 1.0
/// @Authors: Leon Smit
/// </summary>
public abstract class Trigger : MonoBehaviour {
    protected StepHandler stepHandler;

    private void Awake() {
        stepHandler = gameObject.AddComponent<StepHandler>();
    }

    protected void fire() {
        stepHandler.Activate();
    }
}