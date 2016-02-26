using UnityEngine;
using System.Collections;

namespace Assets.CombatActions {

    public abstract class CombatAction : MonoBehaviour {

        protected bool      complete = false;
        public bool Complete {
            get { return complete; }
            set { complete = value; }
        }
        protected Hero      hero;
        protected string    combatantState;
        public string State {
            get { return combatantState; }
        }

        protected int id;
        public int Id {
            get { return id; }
        }

        protected void GetHeroRef() {
            hero = this.gameObject.GetComponent<Hero>();
        }
    }

}
