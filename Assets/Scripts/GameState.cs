using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState {

    private static Scenario currentScenario;
    // private Persona currentPersona;

    // public void setCurrentScenario(Scenario scenario) {
    //     this.currentScenario = scenario;
    // }

    // public void setCurrentPersona(Persona persona) {
    //     this.currentPersona = persona;
    // }

    public Scenario getCurrentScenario() {
        return GameState.currentScenario;
    }

    public void setCurrentScenario(Scenario scenario) {
        GameState.currentScenario = scenario;
    }

    // public Persona getCurrentPersona() {
    //     return this.currentPersona;
    // }

}
