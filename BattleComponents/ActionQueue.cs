using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.CombatActions;

namespace Assets.BattleComponents {
    public class ActionQueue : MonoBehaviour{

        // The actions currently in the queue
        private Queue<CombatAction> actions;

        public CombatAction CurrentAction {
            get {
                    if (actions.Count > 0)
                        return actions.Peek();
                    else
                        return null;
                }
        }

        void Awake() {
            actions = new Queue<CombatAction>();
        }

        void Start() {
            actions = new Queue<CombatAction>();
        }

        void Update() {

            if (actions.Count > 0) {
                if (actions.Peek().Complete == true) {
                    CombatAction action = actions.Dequeue();
                    Destroy(action);

                    // Enable the next action in the queue
                    if(actions.Count > 0)
                        actions.Peek().enabled = true;
                }

            }
        }

        // Adds an action to the end of the queue
        public void AddAction(CombatAction action) {
            actions.Enqueue(action);
        }

        // Removes all currently queue'd actions and sets a default
        public void SetAction(CombatAction action) {

            foreach(CombatAction queuedAction in actions) {
                Destroy(queuedAction);
            }

            actions.Clear();
            actions.Enqueue(action);
        }
    }
}
