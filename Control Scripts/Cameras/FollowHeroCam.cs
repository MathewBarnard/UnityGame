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

            cameraAnchor.transform.position = new Vector3(hero.transform.position.x, hero.transform.position.y + 5.0f, - 5.0f);

            float distance = Vector3.Magnitude(mainCamera.transform.position - cameraAnchor.transform.position);

            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, cameraAnchor.transform.position, (distance * Time.deltaTime) * 5.0f);
        }
    }
}
