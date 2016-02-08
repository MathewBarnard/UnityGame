using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Control_Scripts.Cameras {


    class TacticalViewCam : MonoBehaviour, CameraBehaviour {

        private GameObject cameraAnchor;
        private GameObject mainCamera;

        public TacticalViewCam() {
            cameraAnchor = GameObject.Find("Tactical Cam Base");
            mainCamera = GameObject.Find("Main Camera");
        }

        public void update() {

            float cameraSmoothing = Vector3.Magnitude(mainCamera.transform.position - cameraAnchor.transform.position) * Time.deltaTime;
            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, cameraAnchor.transform.position, cameraSmoothing);
        }
    }
}
