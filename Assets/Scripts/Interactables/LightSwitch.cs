﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is for the lightswitch object. The object takes lightcontroller as object so it knows which lights to turn off/on
/// 
/// @Version: 1.0
/// @Authors: Florian Molenaars
/// </summary>
public class LightSwitch : Interactable {
    public GameObject lightControllerObject;
    private LightController lightcontroller;
    private AudioManager audioManager;

    // Start is called before the first frame update
    public override void OnStart() {
        lightcontroller = lightControllerObject.GetComponent<LightController>();
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    public override void OnUpdate() {
        // Gets called on update
    }

    public override void OnSelect() {
        //throw new System.NotImplementedException();
    }

    public override void OnDeselect() {
        //throw new System.NotImplementedException();
    }

    public override void OnActivate() {
        lightcontroller.Switch();
        audioManager.Play("Switch");
    }

    public override bool isActive() {
        return false;
    }
}