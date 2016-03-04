using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Assets.BattleComponents {

    [Serializable]
    public class Stats : ICloneable {

        private string name;
        public string Name {
            set { name = value; }
            get { return name; }
        }

        private float moveSpeed;
        public float MoveSpeed {
            set { moveSpeed = value; }
            get { return moveSpeed; }
        }

        private float maxEnergy;
        public float MaxEnergy {
            set { maxEnergy = value; }
            get { return maxEnergy; }
        }

        private float energyPerSecond;
        public float EnergyPerSecond {
            set {
                energyPerSecond = value; }
            get { return energyPerSecond; }
        }

        private float range;
        public float Range {
            set { range = value; }
            get { return range; }
        }

        public object Clone() {
            Stats stats = new Stats();
            stats.name = this.name;
            stats.moveSpeed = this.moveSpeed;
            stats.maxEnergy = this.maxEnergy;
            stats.energyPerSecond = this.energyPerSecond;
            stats.range = this.range;

            return stats;
        }
    }
}
