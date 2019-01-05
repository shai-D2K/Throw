using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    public GameObject ballPrefab;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("E");
            GameObject b = Instantiate(ballPrefab, Camera.main.transform.position, Quaternion.Euler(Vector3.zero));

            Rigidbody rig;
            try { rig = b.GetComponent<Rigidbody>(); } catch { Debug.LogError("Missing Compenent"); return; }

            rig.AddForce(Camera.main.transform.forward * 15000f);

        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                if(hit.transform.GetComponent<DynObj>().canDelete)
                {
                    Destroy(hit.transform.gameObject);
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                    Debug.Log("Did Hit");
                }
            }
        }
    }
}
