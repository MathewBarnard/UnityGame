using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.BattleComponents.StatusEffects;

namespace Assets.BattleComponents.StatusEffects {

    /// <summary>
    /// This class is a container for status effects that can affect a combatant. The purpose of the container is to manage the lifetime of status effects,
    /// and their order of execution when determining a combatants end combat state.
    /// </summary>
    public class StatusEffectManager : MonoBehaviour {

        public List<StatusEffect> statusEffects;

        void Awake() {
            statusEffects = new List<StatusEffect>();
        }

        void Update() {
            foreach(StatusEffect effect in statusEffects) {
                Debug.Log(effect);
                if(effect is TickEffect) {
                    // Call the tick function for this effect to have it trigger
                }
            }
        }

        public StatusEffect AddEffect(StatusEffect statusToApply) {

            StatusEffect existingStatus = null;

            if(CheckForEffect(statusToApply, out existingStatus)) {
                existingStatus.Refresh();
            }
            else {
                statusEffects.Add(statusToApply);
            }

            Recalculate();

            if (existingStatus == null)
                return statusToApply;
            else
                return existingStatus;
        }

        public void RemoveEffect(StatusEffect effect) {

            statusEffects.Remove(effect);
            Recalculate();
        }

        private void Recalculate() {

            // Get the base stats for this combatant to be recalculated based on all active status effects 
            Stats baseStats = (Stats)this.GetComponent<Combatant>().BaseStats.Clone();

            foreach(StatusEffect effect in statusEffects) {

                if (effect != null) {
                    effect.Inflict(baseStats);
                }
            }

            this.GetComponent<Combatant>().CurrentStats = baseStats;
        }

        // Checks the effect that is to be applied. If this combatant is already affected by this type of status, we return that instance
        // of it from the collection. Otherwise, we return the status to be applied.
        private bool CheckForEffect(StatusEffect statusToApply, out StatusEffect status) {

            foreach(StatusEffect s in statusEffects) {
                if(s.GetType() == statusToApply.GetType()) {
                    status = s;
                    return true;
                }
            }

            status = null;
            return false;
        }
    }
}
