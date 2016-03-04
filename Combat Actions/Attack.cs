using UnityEngine;
using Assets.CombatActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.AnimationControllers;

// The attack class uses the Animation to test when it has been completed
namespace Assets.CombatActions {
    class Attack : CombatAction, IAnimationControlled {

        private Combatant target;

        void Awake() {
            StoreCombatantReference();
            AttachController();
            id = AnimationState.Attacking;
        }

        public void SetTarget(Combatant target) {
            this.target = target;
        }

        public void AttachController() {

            this.gameObject.transform.FindChild("Sprite").GetComponent<AnimationEventController>().SetAction(this);
        }

        public void TriggerEvent() {
            target.GetComponent<Rigidbody>().AddForce(new Vector3(-100.0f, 100.0f, 0.0f));
        }

        public void AnimationComplete() {
            complete = true;
        }
    }
}
