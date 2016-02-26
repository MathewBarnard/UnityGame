using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Abilities;

namespace Assets.Control_Scripts {
    public class AbilitySet {

        private Ability ablQ;
        private Ability ablE;

        public Ability AbilityQ {

            set { ablQ = value; }
            get { return ablQ; }
        }

        public Ability AbilityE {
            set { ablE = value; }
            get { return ablE; }
        }
    }
}
