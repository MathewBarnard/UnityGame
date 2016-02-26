using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.CombatActions {

    class MoveToTarget : CombatAction {

        private Vector3 targetLocation;
        public Vector3 TargetLocation {
            get { return targetLocation; }
            set { targetLocation = value; }
        }

        void Awake() {
            GetHeroRef();
            id = AnimationState.Moving;
        }

        void Start() {
            combatantState = "Moving";

            if (targetLocation.x < this.transform.position.x)
                hero.DirectionFaced = "Left";
            else
                hero.DirectionFaced = "Right";
        }

        void Update() {
            // Move this combatant towards the target location
            this.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(this.transform.position, targetLocation, hero.MoveSpeed * Time.deltaTime));

            // Check if the combatant has arrived at their location. if they have, remove the script.
            if(this.transform.position == targetLocation) {
                complete = true;
            }
        }
    }
}
