using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// This interface provides functionality for Actions that are controlled by animations. To clarify: a combatant moving has an end condition of
// the player arriving at their target location. A combatatant /attacking/ however, has an end condition of when the attack has dealt damage, and 
// the animation has finished.
namespace Assets.AnimationControllers {

    public interface IAnimationControlled {

        void AttachController();

        void TriggerEvent();

        void AnimationComplete();
    }
}
