using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Control_Scripts;
using Assets.Abilities;
using Assets.CombatActions;
using Assets.BattleComponents;

public class Hero : Combatant {

    // The characters current state
    private string state;
    public string State {
        set { state = value; }
        get { return state; }
    }

    private int animationState = 0;
    public int AnimationState {
        set { animationState = value; }
        get { return animationState; }
    }

    // The heros direction
    private string directionFaced;
    public string DirectionFaced {
        set { directionFaced = value; }
        get { return directionFaced; }
    }

    // The heros action queue
    private ActionQueue actions;
    public ActionQueue Actions {
        get { return actions; }
    }

    public CombatAction CurrentAction {
        get { return actions.CurrentAction; }
    }
    
    // Contains this heros ability set
    private AbilitySet abilitySet;

    private Ability activeAbility;

    ///////////////////////////////////////////////////////////
    /// <summary>
    /// The following should be encapsulated into a seperate class at some point!
    /// They are all stats relative to this combatant. ie attack power, speed, etc.
    /// </summary>

    // This heros move speed
    private float moveSpeed = 1.5f;
    public float MoveSpeed {
        set { moveSpeed = value; }
        get { return moveSpeed; }
    }

    private float range = 0.5f;
    public float Range {
        set { range = value; }
        get { return range; }
    }

    private int attackPower = 10;
    public int AttackPower {
        get { return attackPower; }
    }

    ///////////////////////////////////////////////////////////

    void Awake() {
        actions = this.GetComponent<ActionQueue>();
    }

    void Start() {

        directionFaced = "Left";

        // Default the states
        state = "Idle";

        // The hero should have no ability active
        activeAbility = null;

        // DEFAULT: Manually set the Players Ability Set
        abilitySet = new AbilitySet();
    }

    void Update() {
    }

    /// <summary>
    /// These functions are related to the old ability system which is to be changed
    /// </summary>

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
