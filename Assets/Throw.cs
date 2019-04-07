using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour {

    public GameObject ballPrefab;
    GameObject @base;
    float velocity = 5000f;//15000f
    public bool isPaused = false;

    // Use this for initialization
    void Start () {
        @base = GameObject.Find("Base");
    }

    void Update()
    {
        if (!isPaused)
        {
            Run();
        }
    }

    // Update is called once per frame
    void Run () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("E");
            GameObject b = Instantiate(ballPrefab, Camera.main.transform.position, Quaternion.Euler(Vector3.zero), @base.transform);

            Rigidbody rig;
            try { rig = b.GetComponent<Rigidbody>(); } catch { Debug.LogError("Missing Compenent"); return; }

            rig.AddForce(Camera.main.transform.forward * velocity);

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
