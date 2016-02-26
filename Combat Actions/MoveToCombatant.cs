using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.CombatActions {

    class MoveToCombatant : CombatAction {

        private Combatant target;
        public Combatant Target {
            get { return target; }
            set { target = value; }
        }

        void Awake() {
            GetHeroRef();
            id = AnimationState.Moving;
        }

        void Start() {
            if (target.transform.position.x < this.transform.position.x)
                hero.DirectionFaced = "Left";
            else
                hero.DirectionFaced = "Right";
        }

        void Update() {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, hero.MoveSpeed * Time.deltaTime);
        }

        // Triggers when the target combatant is within range of the target.
        void OnTriggerStay(Collider col) {
            if (col.gameObject == target.gameObject) {
                complete = true;
            }
        }

    }
}
