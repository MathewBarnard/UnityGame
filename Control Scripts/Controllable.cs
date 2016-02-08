using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Defines an object that can be controlled by the player

public interface Controllable {

    void Move(string direction);

    void Target(Vector3 targetLocation);

    void UseAbility(string abilityKey);
}

