using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.BattleComponents.StatusEffects {

    /// <summary>
    /// This debuff is attached to characters who are moving, reducing their energy regeneration. This is to force a trade-off if the player decides to remove their combatant
    /// from danger during an auto-attack cooldown (similar to auto-attack reseting in MOBAs). Players therefore gain more energy for being more consistently in harms way.
    /// This reduces the level of micromanagement that the player will be encouraged to do.
    /// </summary>
    public class MovingReduceEnergy : StatusEffect {

        public MovingReduceEnergy(Combatant combatant) {
            this.affectedCombatant = combatant;
        }

        public override void Inflict(Stats stats) {
            stats.EnergyPerSecond = stats.EnergyPerSecond / 2;
        }

        public override void Update() {
            
        }

        public override void Refresh() {
        }

        public override void Remove() {
            //affectedCombatant.CurrentStats.EnergyPerSecond = affectedCombatant.BaseStats.EnergyPerSecond;
        }
    }
}
