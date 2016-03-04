using UnityEngine;
using System.Collections;
using Assets.CombatActions;

public class PlayerController : MonoBehaviour {

    // The object being controlled by the player
    public Hero focus;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, LayerMask.GetMask("TerrainRaycast"))) {

                // The player has clicked the environment
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("TerrainRaycast"))
                {
                    MoveToTarget combatAction = focus.gameObject.AddComponent<MoveToTarget>();
                    combatAction.TargetLocation = hit.point;
                    focus.Actions.SetAction(combatAction);
                }
                else if(hit.transform.gameObject.tag == "Enemy") {
                    Debug.Log("Enemy clicked");
                    
                    // Attach the script to move towards the target combatant
                    MoveToCombatant combatAction = focus.gameObject.AddComponent<MoveToCombatant>();
                    combatAction.Target = hit.transform.gameObject.GetComponent<Enemy>();
                    focus.Actions.SetAction(combatAction);

                    // Attach the script that will cause the player to attack after he has arrived at the target
                    Attack attackAction = focus.gameObject.AddComponent<Attack>();
                    attackAction.enabled = false;
                    attackAction.SetTarget(hit.transform.gameObject.GetComponent<Enemy>());
                    focus.Actions.AddAction(attackAction);
                }
                // The player has clicked an enemy
                
            }
        }
    }
}
