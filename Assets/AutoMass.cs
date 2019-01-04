using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMass : MonoBehaviour {

	void Awake () {

        Re();
    }
    public void Re()
    {
        Rigidbody rig;
        try { rig = GetComponent<Rigidbody>(); } catch { return; }

        rig.mass = Mathf.Pow((transform.localScale.x * transform.localScale.y * transform.localScale.z), 1.0f);
    }
	
}
