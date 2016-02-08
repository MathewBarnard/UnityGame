using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Control_Scripts;
using Assets.Abilities;

public class Hero : MonoBehaviour, Controllable {

    // The heros direction
    private string directionFaced;
    public string DirectionFaced {
        set { directionFaced = value; }
        get { return directionFaced; }
    }

    // Contains this heros ability set
    private AbilitySet abilitySet;

    private Ability activeAbility;

    private const float moveSpeed = 3.0f;

    void Start() {

        directionFaced = "Left";

        // The hero should have no ability active
        activeAbility = null;

        // DEFAULT: Manually set the Players Ability Set
        abilitySet = new AbilitySet();
        abilitySet.AbilityQ = new AirSlash();
        abilitySet.AbilityE = new AirSlash();
    }

    void Update() {

        // Set the direction
        switch(directionFaced) {
            case "Left":
                this.transform.FindChild("Sprite").localScale = new Vector3(1.0f, 1.0f, 1.0f);
                break;
            case "Right":
                this.transform.FindChild("Sprite").localScale = new Vector3(-1.0f, 1.0f, 1.0f);
                break;
        }
    }

    public void Move(string direction) {

        if(activeAbility != null && activeAbility.State == Ability.AbilityState.EXECUTING) {
            return;
        }

        switch(direction) {

            case "Up":
                this.gameObject.transform.Translate(new Vector3(0.0f, 0.0f, moveSpeed) * Time.deltaTime);
                break;

            case "Left":
                this.gameObject.transform.Translate(new Vector3(-moveSpeed, 0.0f, 0.0f) * Time.deltaTime);
                directionFaced = "Left";
                break;

            case "Down":
                this.gameObject.transform.Translate(new Vector3(0.0f, 0.0f, -moveSpeed) * Time.deltaTime);
                break;

            case "Right":
                this.gameObject.transform.Translate(new Vector3(moveSpeed, 0.0f, 0.0f) * Time.deltaTime);
                directionFaced = "Right";
                break;
        }
    }

    public void Target(Vector3 targetLocation) {
        GameObject.Find("Target").transform.position = new Vector3(targetLocation.x, 0.001f, targetLocation.z);
    }

    public void UseAbility(string abilityKey) {

        // No abilities can be executed if another one is being executed, so break out!
        if(activeAbility != null && activeAbility.State == Ability.AbilityState.EXECUTING) {
            return;
        }

       // First, remove the currently active ability from the stack
       Destroy(activeAbility);

       switch(abilityKey) {

            case "Q":
                activeAbility = (Ability)this.gameObject.AddComponent(abilitySet.AbilityQ.GetType());
                break;
            case "E":
                activeAbility = (Ability)this.gameObject.AddComponent(abilitySet.AbilityE.GetType());
                break;
            default:
                break;
        }
    }
}
