using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInRange : MonoBehaviour {

    Vector3 rangeLow = new Vector3(-150, 0, -150);
    Vector3 rangeHigh = new Vector3(150, 150, 150);
    float nudge = 2f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > rangeHigh.x)
        {
            transform.position = new Vector3(rangeHigh.x - nudge, transform.position.y, transform.position.z);
        }

        if (transform.position.y > rangeHigh.y)
        {
            transform.position = new Vector3(transform.position.x, rangeHigh.y - nudge, transform.position.z);
        }

        if (transform.position.z > rangeHigh.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rangeHigh.z - nudge);
        }


        if (transform.position.x < rangeLow.x)
        {
            transform.position = new Vector3(rangeLow.x + nudge, transform.position.y, transform.position.z);
        }

        if (transform.position.y < rangeLow.y)
        {
            transform.position = new Vector3(transform.position.x, rangeLow.y + nudge, transform.position.z);
        }

        if (transform.position.z < rangeLow.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, rangeLow.z + nudge);
        }
    }
}
