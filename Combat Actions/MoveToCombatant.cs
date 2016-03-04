using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.BattleComponents.StatusEffects;

namespace Assets.CombatActions {

    class MoveToCombatant : CombatAction {

        private StatusEffect reduceEnergyDebuff;

        private Combatant target;
        public Combatant Target {
            get { return target; }
            set { target = value; }
        }

        void Awake() {
            StoreCombatantReference();
            id = AnimationState.Moving;
        }

        void Start() {

            reduceEnergyDebuff = combatant.StatusEffectManager.AddEffect(new MovingReduceEnergy(combatant));

            if (target.transform.position.x < this.transform.position.x)
                combatant.DirectionFaced = "Left";
            else
                combatant.DirectionFaced = "Right";
        }

        void Update() {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, combatant.CurrentStats.MoveSpeed * Time.deltaTime);
        }

        // Triggers when the target combatant is within range of the target.
        void OnTriggerStay(Collider col) {
            if (col.gameObject == target.gameObject) {
                combatant.StatusEffectManager.RemoveEffect(reduceEnergyDebuff);
                complete = true;
            }
        }

    }
}
