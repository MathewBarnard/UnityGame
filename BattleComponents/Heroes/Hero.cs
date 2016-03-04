using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Control_Scripts;
using Assets.Abilities;
using Assets.CombatActions;
using Assets.BattleComponents;
using Assets.BattleComponents.StatusEffects;

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

    void Awake() {
        actions = this.GetComponent<ActionQueue>();

        statusEffectManager = this.GetComponent<StatusEffectManager>();

        // Hard code this Heros stats for initial file creation
        Stats stats = new Stats();
        stats.Name = "Hero";
        stats.EnergyPerSecond = 5.0f;
        stats.Range = 0.5f;
        stats.MoveSpeed = 1.5f;
        stats.MaxEnergy = 100.0f;

        Assets.Utility.DataAccess.StatDAO.Save(stats);
        stats = Assets.Utility.DataAccess.StatDAO.GetByName("Hero");


        currentStats = new Stats();
        // Set the current Combatant stats to the base stats
        currentStats.Name               = stats.Name;
        currentStats.EnergyPerSecond = stats.EnergyPerSecond;
        currentStats.Range = stats.Range;
        currentStats.MoveSpeed = stats.MoveSpeed;
        currentStats.MaxEnergy = stats.MaxEnergy;

        baseStats = stats;
    }

    void Start() {

        directionFaced = "Left";

        // Default the states
        state = "Idle";
    }

    void Update() {
        Debug.Log(currentStats.EnergyPerSecond);
    }
}
