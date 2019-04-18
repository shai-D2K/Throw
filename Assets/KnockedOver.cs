using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockedOver : MonoBehaviour {

    public Vector3 origPosition;
    public bool knockedOver = false;

	// Use this for initialization
	void Start () {
        origPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!knockedOver && (Mathf.Abs(Mathf.Abs(origPosition.x) - Mathf.Abs(transform.position.x)) > 1f || Mathf.Abs(Mathf.Abs(origPosition.y) - Mathf.Abs(transform.position.y)) > 1f || Mathf.Abs(Mathf.Abs(origPosition.z) - Mathf.Abs(transform.position.z)) > 1f))
        {
            knockedOver = true;
        }
	}
}
