using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMass : MonoBehaviour {

    public bool sphere = false;
    float maxMass = 1f;
    float minMass = 0.25f;

	void Awake () {

        //Re();
    }
    public void Re(int current, int max)
    {
        /*Rigidbody rig;
        //try { rig = GetComponent<Rigidbody>(); } catch { return; }
        rig = GetComponent<Rigidbody>();

        if (!sphere)
        {
            rig.mass = (transform.localScale.x * transform.localScale.y * transform.localScale.z);
        }
        else
        {
            rig.mass = (4 / 3) * Mathf.PI * Mathf.Pow(transform.localScale.x, 3);
        }*/

        Rigidbody rig;
        try { rig = GetComponent<Rigidbody>(); } catch { return; }
        rig = GetComponent<Rigidbody>();
        float mass = maxMass - (((float)current / (float)max) * maxMass);
        rig.mass = (mass > minMass) ? mass : minMass;

    }
	
}
