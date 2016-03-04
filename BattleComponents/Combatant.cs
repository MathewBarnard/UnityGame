using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.CombatActions;
using Assets.BattleComponents;
using Assets.BattleComponents.StatusEffects;


public class Combatant : MonoBehaviour {

    // This is the combatants current energy pool.
    // It will regenerate at a rate defined by "energyPerSecond"
    protected Stats baseStats;
    public Stats BaseStats {
        get { return baseStats; }
        set { baseStats = value; }
    }

    protected Stats currentStats;
    public Stats CurrentStats {
        get { return currentStats; }
        set { currentStats = value; }
    }

    // The combatants status effect manager
    protected StatusEffectManager statusEffectManager;
    public StatusEffectManager StatusEffectManager {
        get { return statusEffectManager; }
        set { statusEffectManager = value; }
    }

    // The heros action queue
    protected ActionQueue actions;
    public ActionQueue Actions {
        get { return actions; }
    }

    public CombatAction CurrentAction {
        get { return actions.CurrentAction; }
    }

    protected float energy;
    public float Energy {
        get { return energy; }
        set { energy = value; }
    }

    // The heros direction
    protected string directionFaced;
    public string DirectionFaced {
        set { directionFaced = value; }
        get { return directionFaced; }
    }

    void Awake() {

        if(currentStats == null)
            currentStats = new Stats();

        if(baseStats == null) 
            baseStats = new Stats();
    }

    void Start() {
        energy = 0.0f;
    }

    void Update() {

        energy += currentStats.EnergyPerSecond * Time.deltaTime;
        //Debug.Log(energy);
    }
}

