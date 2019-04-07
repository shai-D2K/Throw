using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour {

    FlyCamera cam;
    Create create;

    public Slider slideSens;
    public InputField txtFloor;
    public InputField txtNS;
    public InputField txtEW;

    float sensitivity = 0.25f;
    int floors = 8;
    int ns = 7;
    int ew = 7;

    // Use this for initialization
    void Start () {
        cam = FindObjectOfType<FlyCamera>();
        create = FindObjectOfType<Create>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetSettings()
    {
        cam.camSens = sensitivity;
        create.floors = floors;
        create.sideNS = ns;
        create.sideEW = ew;
    }

    public void PopulateFields()
    {
        slideSens.value = sensitivity;
        txtFloor.text = floors.ToString();
        txtNS.text = ns.ToString();
        txtEW.text = ew.ToString();
    }

    public void LoadFields()
    {
        sensitivity = slideSens.value;
        floors = Convert.ToInt32(txtFloor.text);
        ns = Convert.ToInt32(txtNS.text);
        ew = Convert.ToInt32(txtEW.text);
    }
}
