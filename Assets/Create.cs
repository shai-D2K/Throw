using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

    public GameObject planePre;
    public GameObject cubePre;
    int floors = 8;
    int sideNS = 7;
    int sideEW = 6;

    Vector3 mainSup = new Vector3(1.5f, 4, 1.5f);
    Vector3 crossBarNS = new Vector3(7, 0.5f, 0.5f);
    Vector3 crossBarEW = new Vector3(0.5f, 0.5f, 7);
    Vector3 tiny = new Vector3(0.5f, 0.5f, 0.5f);
    GameObject[,,] pills;

	// Use this for initialization
	void Start () {
        pills = new GameObject[floors,sideNS,sideEW];

        GameObject p = Instantiate(planePre, Vector3.zero, Quaternion.Euler(0, 0, 0));
        p.transform.localScale = new Vector3(20, 20, 20);

        for(int f = 0; f < floors; f++)
        {
            for(int sNS = 0; sNS < sideNS; sNS++)
            {
                for (int sEW = 0; sEW < sideEW; sEW++)
                {
                    GameObject g = Instantiate(cubePre, new Vector3(
                        ((crossBarNS.x / 2f) + crossBarNS.x * sNS), 
                        ((mainSup.y / 2f) + mainSup.y * f) + (crossBarNS.y * f), 
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW)
                        ), Quaternion.Euler(0, 0, 0));
                    g.transform.localScale = mainSup;
                    
                    pills[f, sNS, sEW] = g;
                }
            }
        }

        /*/ Mid
        for (int f = 0; f < floors; f++)
        {
            for (int sNS = 0; sNS < sideNS; sNS++)
            {
                for (int sEW = 0; sEW < sideEW; sEW++)
                {
                    GameObject g = Instantiate(cubePre, new Vector3(
                        ((crossBarNS.x / 2f) + crossBarNS.x * sNS),
                        ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW)
                        ), Quaternion.Euler(0, 0, 0));
                    g.transform.localScale = tiny;
                    //g.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g.AddComponent(typeof(FixedJoint));
                    g.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();

                    GameObject g1 = Instantiate(cubePre, new Vector3(
                       ((crossBarNS.x / 2f) + crossBarNS.x * sNS) - (mainSup.x / 3f),
                       ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                       ((crossBarEW.z / 2f) + crossBarEW.z * sEW) - (mainSup.x / 3f)
                       ), Quaternion.Euler(0, 0, 0));
                    g1.transform.localScale = tiny;
                    //g1.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g1.AddComponent(typeof(FixedJoint));
                    g1.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();

                    GameObject g2 = Instantiate(cubePre, new Vector3(
                       ((crossBarNS.x / 2f) + crossBarNS.x * sNS) + (mainSup.x / 3f),
                       ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                       ((crossBarEW.z / 2f) + crossBarEW.z * sEW) - (mainSup.x / 3f)
                       ), Quaternion.Euler(0, 0, 0));
                    g2.transform.localScale = tiny;
                    //g2.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g2.AddComponent(typeof(FixedJoint));
                    g2.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();

                    GameObject g3 = Instantiate(cubePre, new Vector3(
                       ((crossBarNS.x / 2f) + crossBarNS.x * sNS) + (mainSup.x / 3f),
                       ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                       ((crossBarEW.z / 2f) + crossBarEW.z * sEW) + (mainSup.x / 3f)
                       ), Quaternion.Euler(0, 0, 0));
                    g3.transform.localScale = tiny;
                    //g3.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g3.AddComponent(typeof(FixedJoint));
                    g3.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();

                    GameObject g4 = Instantiate(cubePre, new Vector3(
                       ((crossBarNS.x / 2f) + crossBarNS.x * sNS) - (mainSup.x / 3f),
                       ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                       ((crossBarEW.z / 2f) + crossBarEW.z * sEW) + (mainSup.x / 3f)
                       ), Quaternion.Euler(0, 0, 0));
                    g4.transform.localScale = tiny;
                    //g4.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g4.AddComponent(typeof(FixedJoint));
                    g4.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();
                }
            }
        }
        */

        for (int f = 0; f < floors; f++)
        {
            // NS
            for (int sNS = 0; sNS < sideNS - 1; sNS++)
            {
                for (int sEW = 0; sEW < sideEW; sEW++)
                {
                    GameObject g = Instantiate(cubePre, new Vector3(
                        ((crossBarNS.x / 2f) + crossBarNS.x * sNS) + (crossBarNS.x / 2f),
                        ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW)
                        ), Quaternion.Euler(0, 0, 0));
                    g.transform.localScale = crossBarNS;
                    g.transform.localScale = new Vector3(g.transform.localScale.x - (mainSup.x / 3f), g.transform.localScale.y, g.transform.localScale.z);
                }
            }

            // EW
            for (int sNS = 0; sNS < sideNS; sNS++)
            {
                for (int sEW = 0; sEW < sideEW - 1; sEW++)
                {
                    GameObject g = Instantiate(cubePre, new Vector3(
                        ((crossBarNS.x / 2f) + crossBarNS.x * sNS),
                        ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW) + (crossBarEW.z / 2f)
                        ), Quaternion.Euler(0, 0, 0));
                    g.transform.localScale = crossBarEW;
                    g.transform.localScale = new Vector3(g.transform.localScale.x, g.transform.localScale.y, g.transform.localScale.z - (mainSup.x / 3f));
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            DynObj[] objs = FindObjectsOfType<DynObj>();

            for(int i = 0; i < objs.Length; i++)
            {
                Destroy(objs[i].gameObject);
            }

            Start();
        }
	}
}
