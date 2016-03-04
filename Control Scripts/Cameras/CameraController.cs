using UnityEngine;
using System.Collections;
using Assets.Control_Scripts.Cameras;

public class CameraController : MonoBehaviour {

    public Camera mainCamera;
    private CameraBehaviour currentBehaviour;

	// Use this for initialization
	void Start () {
        //currentBehaviour = new FollowHeroCam(GameObject.Find("Hero"), GameObject.Find("Main Camera Base"));

        currentBehaviour = new TacticalViewCam();
	}
	
	// Update is called once per frame
	void Update () {
        CheckInput();

        currentBehaviour.update();
	}

    private void CheckInput() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            
            if(currentBehaviour is FollowHeroCam) {
                currentBehaviour = new TacticalViewCam();
            }
            else {
                currentBehaviour = new FollowHeroCam(GameObject.Find("Hero"), GameObject.Find("Main Camera Base"));
            }
        }
    }
}
