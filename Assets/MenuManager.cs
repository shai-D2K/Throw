using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {

    OptionsManager options;
    public bool menuOpen = false;

    public GameObject menuPanel;

    FlyCamera cam;
    Throw @throw;

    // Use this for initialization
    void Start () {
        options = GetComponent<OptionsManager>();
        cam = FindObjectOfType<FlyCamera>();
        @throw = FindObjectOfType<Throw>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(menuOpen)
            {
                CloseMenu();
            }
            else
            {
                OpenMenu();
            }
        }
    }

    public void OpenMenu()
    {
        menuOpen = true;
        options.PopulateFields();
        Cursor.lockState = CursorLockMode.None;
        cam.isPaused = true;
        @throw.isPaused = true;
        menuPanel.gameObject.SetActive(true);
    }

    public void CloseMenu()
    {
        menuOpen = false;
        options.LoadFields();
        options.SetSettings();
        Cursor.lockState = CursorLockMode.Locked;
        cam.isPaused = false;
        @throw.isPaused = false;
        menuPanel.gameObject.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
