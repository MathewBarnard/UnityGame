using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    // The object being controlled by the player
    public Hero focus;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.W)) {

            focus.Move("Up");
        }

        if (Input.GetKey(KeyCode.A)) {

            focus.Move("Left");
        }

        if (Input.GetKey(KeyCode.S)) {

            focus.Move("Down");
        }

        if (Input.GetKey(KeyCode.D)) {

            focus.Move("Right");
        }

        if (Input.GetKeyDown(KeyCode.Q)) {
            focus.UseAbility("Q");
        }

        if (Input.GetKeyDown(KeyCode.E)) {
            focus.UseAbility("E");
        }
    }
}
