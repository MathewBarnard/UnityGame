using UnityEngine;
using System.Collections;

namespace Assets.CombatActions {

    public abstract class CombatAction : MonoBehaviour {

        protected bool      complete = false;
        public bool Complete {
            get { return complete; }
            set { complete = value; }
        }
        protected Combatant      combatant;
        protected string    combatantState;
        public string State {
            get { return combatantState; }
        }

        protected int id;
        public int Id {
            get { return id; }
        }

        protected void StoreCombatantReference() {
            combatant = this.gameObject.GetComponent<Combatant>();
        }
    }

}
