using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.BattleComponents.StatusEffects { 

    public abstract class StatusEffect {

        protected Combatant affectedCombatant;

        protected float duration;

        public abstract void Inflict(Stats stats);

        public abstract void Update();

        public abstract void Refresh();

        public abstract void Remove();
    }
}
