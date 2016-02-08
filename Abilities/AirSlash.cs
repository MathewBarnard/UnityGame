using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Abilities {
    public class AirSlash : Ability {

        private GameObject reticule;
        private float cooldown;

        // Air Slash targets a location decided by the player. The target parameter is set when the player LEFT CLICKS a location while the reticule is active.
        // This spawns a target point for the Air Slash to travel to.
        public override void Target() {

            reticule = GameObject.Find("Target");

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("TerrainRaycast"))) {
                reticule.gameObject.transform.position = new Vector3(hit.point.x, 0.01f, hit.point.z);
            }

            // Check for user input
            if(Input.GetButtonDown("Fire1")) {

                if (Physics.Raycast(ray, out hit, 100)) {
                    state = AbilityState.EXECUTING;
                    cooldown = 0.5f;

                    GameObject projectile = (GameObject)Instantiate(Resources.Load("Prefabs\\AirSlash", typeof(GameObject)), this.transform.position, new Quaternion());

                    projectile.GetComponent<Projectiles.AirSlash>().Direction = Vector3.Normalize(new Vector3(hit.point.x - this.transform.position.x,
                                                                             0.01f,
                                                                             hit.point.z - this.transform.position.z));
                }
            }
        }

        public override void Execute() {
            cooldown -= Time.deltaTime;

            if(cooldown <= 0.0f) {
                state = AbilityState.CLEANUP;
            }
        }

        public override void Cleanup() {

            // Perform any cleanup operations required on the hero, then detach the script
            Destroy(this);
        }

        public override void Interrupt() {
            throw new NotImplementedException();
        }
    }
}
