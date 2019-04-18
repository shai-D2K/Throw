using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Create : MonoBehaviour {

    public GameObject planePre;
    public GameObject cubePre;
    public int floors = 8;
    public int sideNS = 7;
    public int sideEW = 7;
    

    Vector3 mainSup = new Vector3(1.5f, 4, 1.5f);
    Vector3 crossBarNS = new Vector3(7, 0.5f, 0.5f);
    Vector3 crossBarEW = new Vector3(0.5f, 0.5f, 7);
    Vector3 tiny = new Vector3(0.5f, 0.5f, 0.5f);
    GameObject[,,] pills;

	// Use this for initialization
	void Start () {
        //txtFloor.text = floors.ToString();
        //txtNS.text = sideNS.ToString();
        //txtEW.text = sideEW.ToString();
        Fill();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
	}

    public void Reload()
    {
        DynObj[] objs = FindObjectsOfType<DynObj>();

        for (int i = 0; i < objs.Length; i++)
        {
            Destroy(objs[i].gameObject);
        }

        Fill();
    }

    void Fill()
    {
        //floors = Convert.ToInt32(txtFloor.text);
        //sideNS = Convert.ToInt32(txtNS.text);
        //sideEW = Convert.ToInt32(txtEW.text);

        pills = new GameObject[floors, sideNS, sideEW];

        GameObject @base = GameObject.Find("Base");
        @base.transform.position = Vector3.zero;

        GameObject inner = GameObject.Find("Inner");
        inner.transform.position = Vector3.zero;


        GameObject p = Instantiate(planePre, Vector3.zero, Quaternion.Euler(0, 0, 0), @base.transform);
        p.transform.localScale = new Vector3(30, 30, 30);

        for (int f = 0; f < floors; f++)
        {
            for (int sNS = 0; sNS < sideNS; sNS++)
            {
                for (int sEW = 0; sEW < sideEW; sEW++)
                {
                    GameObject g = Instantiate(cubePre, new Vector3(
                        ((crossBarNS.x / 2f) + crossBarNS.x * sNS),
                        ((mainSup.y / 2f) + mainSup.y * f) + (crossBarNS.y * f),
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW)
                        ), Quaternion.Euler(0, 0, 0), inner.transform);
                    g.transform.localScale = mainSup;
                    g.GetComponent<AutoMass>().Re(f, floors);

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
                        ), Quaternion.Euler(0, 0, 0), @base.transform);
                    g.transform.localScale = tiny;
                    //g.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g.AddComponent(typeof(FixedJoint));
                    g.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();

                    GameObject g1 = Instantiate(cubePre, new Vector3(
                       ((crossBarNS.x / 2f) + crossBarNS.x * sNS) - (mainSup.x / 3f),
                       ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                       ((crossBarEW.z / 2f) + crossBarEW.z * sEW) - (mainSup.x / 3f)
                       ), Quaternion.Euler(0, 0, 0), @base.transform);
                    g1.transform.localScale = tiny;
                    //g1.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g1.AddComponent(typeof(FixedJoint));
                    g1.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();

                    GameObject g2 = Instantiate(cubePre, new Vector3(
                       ((crossBarNS.x / 2f) + crossBarNS.x * sNS) + (mainSup.x / 3f),
                       ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                       ((crossBarEW.z / 2f) + crossBarEW.z * sEW) - (mainSup.x / 3f)
                       ), Quaternion.Euler(0, 0, 0), @base.transform);
                    g2.transform.localScale = tiny;
                    //g2.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g2.AddComponent(typeof(FixedJoint));
                    g2.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();

                    GameObject g3 = Instantiate(cubePre, new Vector3(
                       ((crossBarNS.x / 2f) + crossBarNS.x * sNS) + (mainSup.x / 3f),
                       ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                       ((crossBarEW.z / 2f) + crossBarEW.z * sEW) + (mainSup.x / 3f)
                       ), Quaternion.Euler(0, 0, 0), @base.transform);
                    g3.transform.localScale = tiny;
                    //g3.GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Discrete;
                    g3.AddComponent(typeof(FixedJoint));
                    g3.GetComponent<FixedJoint>().connectedBody = pills[f, sNS, sEW].GetComponent<Rigidbody>();

                    GameObject g4 = Instantiate(cubePre, new Vector3(
                       ((crossBarNS.x / 2f) + crossBarNS.x * sNS) - (mainSup.x / 3f),
                       ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                       ((crossBarEW.z / 2f) + crossBarEW.z * sEW) + (mainSup.x / 3f)
                       ), Quaternion.Euler(0, 0, 0), @base.transform);
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
                        ), Quaternion.Euler(0, 0, 0), inner.transform);
                    g.transform.localScale = crossBarNS;
                    g.transform.localScale = new Vector3(g.transform.localScale.x - (mainSup.x / 3f), g.transform.localScale.y, g.transform.localScale.z);
                    g.GetComponent<AutoMass>().Re(f, floors);
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
                        ), Quaternion.Euler(0, 0, 0), inner.transform);
                    g.transform.localScale = crossBarEW;
                    g.transform.localScale = new Vector3(g.transform.localScale.x, g.transform.localScale.y, g.transform.localScale.z - (mainSup.x / 3f));
                    g.GetComponent<AutoMass>().Re(f, floors);
                }
            }
        }

        // Roof
        /*for (int sNS = 0; sNS < sideNS - 1; sNS++)
        {
            for (int sEW = 0; sEW < sideEW - 1; sEW++)
            {
                GameObject g = Instantiate(cubePre, new Vector3(
                        ((crossBarNS.x / 2f) + crossBarNS.x * sNS) + (crossBarNS.x / 2f),
                        ((mainSup.y / 2f) + mainSup.y * floors) + ((crossBarNS.y / 2f) + crossBarNS.y * floors) + mainSup.y / 2f,
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW) + (crossBarEW.z / 2f)
                        ), Quaternion.Euler(0, 0, 0), @base.transform);
                g.transform.localScale = new Vector3(crossBarNS.x, tiny.y, crossBarEW.z);
                g.GetComponent<AutoMass>().Re();
            }
        }*/



        inner.transform.position = new Vector3(-((crossBarNS.x * sideNS) / 2), 0, -((crossBarEW.z * sideEW) / 2));
    }
}
