using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Control_Scripts.Cameras {

    class FollowHeroCam : CameraBehaviour {

        private GameObject hero;
        private GameObject cameraAnchor;
        private GameObject mainCamera;
        private float distanceFromHero = 4.0f;

        public FollowHeroCam(GameObject hero, GameObject cameraAnchor) {
            this.hero = hero;
            this.cameraAnchor = cameraAnchor;
            this.mainCamera = GameObject.Find("Main Camera");
        }

        public void update() {

            string direction = hero.GetComponent<Hero>().DirectionFaced;
            float offset = 0.5f;

            if (direction.Equals("Left")) {
                offset *= -1;
            }

            cameraAnchor.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y + 4.0f, hero.transform.position.z - 3.0f);

            float distance = Vector3.Magnitude(mainCamera.transform.position - cameraAnchor.transform.position);

            Vector3 dir = Vector3.Normalize(mainCamera.transform.position - cameraAnchor.transform.position);

            Vector3 halfwayPoint = dir * distance;

            float cameraSmoothing = (Vector3.Magnitude(mainCamera.transform.position - cameraAnchor.transform.position) * Time.deltaTime) / 3.0f;

            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, halfwayPoint, cameraSmoothing);
        }
    }
}
