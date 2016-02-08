using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Abilities.Projectiles {
    class AirSlash : MonoBehaviour {

        private GameObject target;

        private float timeRemaining;

        private float movementSpeed;

        private Vector3 direction;

        public Vector3 Direction {
            set { direction = value; }
            get { return direction; }
        }

        void Start() {
            timeRemaining = 10.0f;
            movementSpeed = 1.0f;
        }

        void Update() {
            timeRemaining -= Time.deltaTime;

            this.gameObject.transform.Translate((direction * movementSpeed) * Time.deltaTime);

            if(timeRemaining <= 0) {
                Destroy(this.gameObject);
            }
        }
    }
}
