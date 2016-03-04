using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.BattleComponents.StatusEffects;

namespace Assets.CombatActions {

    class MoveToTarget : CombatAction {

        private StatusEffect reduceEnergyDebuff;

        private Vector3 targetLocation;
        public Vector3 TargetLocation {
            get { return targetLocation; }
            set { targetLocation = value; }
        }

        void Awake() {
            StoreCombatantReference();
            id = AnimationState.Moving;
        }

        void Start() {

            reduceEnergyDebuff = combatant.StatusEffectManager.AddEffect(new MovingReduceEnergy(combatant));

            Debug.Log(reduceEnergyDebuff);

            combatantState = "Moving";

            if (targetLocation.x < this.transform.position.x)
                combatant.DirectionFaced = "Left";
            else
                combatant.DirectionFaced = "Right";
        }

        void Update() {
            // Move this combatant towards the target location
            this.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(this.transform.position, targetLocation, combatant.CurrentStats.MoveSpeed * Time.deltaTime));

            // Check if the combatant has arrived at their location. if they have, remove the script.
            if(this.transform.position == targetLocation) {
                combatant.StatusEffectManager.RemoveEffect(reduceEnergyDebuff);
                complete = true;
            }
        }
    }
}
