using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Abilities {
    public abstract class Ability : MonoBehaviour {

        public enum AbilityState { TARGETING, EXECUTING, INTERRUPTED, CLEANUP };

        protected string name { get; set; }

        protected AbilityState state;

        public AbilityState State {
            set { state = value; }
            get { return state; }
        }

        // Defines the target of the ability. This will be rewritten to 'COMBATANT' in future
        private GameObject target;

        void Update() {

            switch (state) {
                case AbilityState.TARGETING:
                    Target();
                    break;
                case AbilityState.EXECUTING:
                    Execute();
                    break;
                case AbilityState.CLEANUP:
                    Cleanup();
                    break;
                case AbilityState.INTERRUPTED:
                    Interrupt();
                    break;
                default:
                    break;
            }
        }

        // Every ability must implement some form of targeting mechanism, which must be fulfilled or cancelled before
        // it can be used.
        public abstract void Target();

        // Every ability must be executed assuming the targetting parameters have been fulfilled. The ability will follow
        // this execute cycle every frame unless interrupted.
        public abstract void Execute();

        public abstract void Cleanup();

        public abstract void Interrupt();
    }
}
