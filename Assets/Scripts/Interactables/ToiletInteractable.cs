using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Let's the player sit on the toilet and disables movement if a step is active (To make player stuck on toilet)
/// @Version: 1.0
/// @Authors: Leon Smit, Daniël Geerts
/// </summary>
public class ToiletInteractable : Interactable {

    public Transform onTheToilerLocation;
    public Player player;
    private Transform locationBeforeSittingOnToilet;

    private bool isSittingOnTheToilet = false;

    public override void OnStart() { }

    public override bool isActive() {
        return isSittingOnTheToilet;
    }

    public override void OnActivate() {
        if (stepHandler) {
            sitOnToilet();
        }
    }

    private void sitOnToilet() {
        locationBeforeSittingOnToilet = player.GetComponent<Transform>();
        player.transform.SetPositionAndRotation(onTheToilerLocation.transform.position, onTheToilerLocation.transform.rotation);
        if (stepHandler.IsActive()) {
            player.disablePlayerControls();
        }

        this.GetComponent<BoxCollider>().isTrigger = true;
        isSittingOnTheToilet = true;
        StartCoroutine(waitAmoutOfSeconds(5));
    }

    IEnumerator waitAmoutOfSeconds(int amountInSeconds) {
        for (float i = 0; i <= amountInSeconds; i += Time.deltaTime) {
            yield return null;
        }
        getOffToilet();
    }

    private void getOffToilet() {
        player.transform.SetPositionAndRotation(locationBeforeSittingOnToilet.transform.position, locationBeforeSittingOnToilet.transform.rotation);
        player.enablePlayerControls();
        isSittingOnTheToilet = false;
    }

    public override void OnDeselect() {

    }

    public override void OnSelect() {

    }

    private float smooth = 5.0f;
    private float tiltAngle = 60.0f;

    public override void OnUpdate() { }
}