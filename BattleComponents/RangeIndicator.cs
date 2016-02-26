using UnityEngine;
using System.Collections;

public class RangeIndicator : MonoBehaviour {

    private float range;
    private SphereCollider sphere;

    void Awake() {
        
    }

	// Use this for initialization
	void Start () {
        range = this.GetComponent<Hero>().Range;
        sphere = this.GetComponent<SphereCollider>();
        sphere.radius = range;
        sphere.isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
