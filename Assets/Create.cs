using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create : MonoBehaviour {

    public GameObject planePre;
    public GameObject cubePre;
    float floors = 4;
    float sideNS = 7;
    float sideEW = 6;

    Vector3 mainSup = new Vector3(1, 4, 1);
    Vector3 crossBarNS = new Vector3(9, 0.5f, 0.5f);
    Vector3 crossBarEW = new Vector3(0.5f, 0.5f, 9);
    Vector3 tiny = new Vector3(0.5f, 0.5f, 0.5f);

	// Use this for initialization
	void Start () {
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
                        ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f), 
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW)
                        ), Quaternion.Euler(0, 0, 0));
                    g.transform.localScale = mainSup;
                }
            }
        }

        for (int f = 0; f < floors; f++)
        {
            // NS
            for (int sNS = 0; sNS < sideNS - 1; sNS++)
            {
                for (int sEW = 0; sEW < sideEW; sEW++)
                {
                    GameObject g = Instantiate(cubePre, new Vector3(
                        ((crossBarNS.x / 2f) + crossBarNS.x * sNS) + crossBarNS.x / 2f,
                        ((mainSup.y / 2f) + mainSup.y * f) + ((crossBarNS.y / 2f) + crossBarNS.y * f) + mainSup.y / 2f,
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW)
                        ), Quaternion.Euler(0, 0, 0));
                    g.transform.localScale = crossBarNS;
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
                        ((crossBarEW.z / 2f) + crossBarEW.z * sEW) + crossBarEW.z / 2f
                        ), Quaternion.Euler(0, 0, 0));
                    g.transform.localScale = crossBarEW;
                }
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
