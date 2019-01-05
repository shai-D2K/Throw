using UnityEngine;
using System.Collections;
 
public class FlyCamera : MonoBehaviour {
 
    /*
    Writen by Windexglow 11-13-10.  Use it, edit it, steal it I don't care.  
    Converted to C# 27-02-13 - no credit wanted.
    Simple flycam I made, since I couldn't find any others made public.  
    Made simple to use (drag and drop, done) for regular keyboard layout  
    wasd : basic movement
    shift : Makes camera accelerate
    space : Moves camera on X and Z axis only.  So camera doesn't gain any height*/
     
     
    float mainSpeed = 25.0f; //regular speed
    float shiftAdd = 50.0f; //multiplied by how long shift is held.  Basically running
    float maxShift = 1000.0f; //Maximum speed when holdin gshift
    float camSens = 0.25f; //How sensitive it with mouse
    private Vector3 lastMouse = new Vector3(0, 0, 0); //kind of in the middle of the screen, rather than at the top (play)
    private float totalRun= 1.0f;
    Vector3 mouseThing = new Vector3(0, 0, 0);
    float newSens = 6f;

    private void Awake()
    {
        
    }

    private void Start()
    {
        Debug.Log(Input.GetAxis("Mouse X") + " " + Input.GetAxis("Mouse Y"));
    }

    void Update () {
        mouseThing = new Vector3(mouseThing.x + (Input.GetAxis("Mouse X") * newSens), mouseThing.y + (Input.GetAxis("Mouse Y") * newSens), mouseThing.z);

        lastMouse = mouseThing - lastMouse ;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0 );
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = mouseThing;
        //Mouse  camera angle done.  
       
        //Keyboard commands
        float f = 0.0f;
        Vector3 p = GetBaseInput();
        if (Input.GetKey (KeyCode.LeftShift)){
            totalRun += Time.deltaTime;
            p  = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else{
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }
       
        p = p * Time.deltaTime;
       Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.Space)){ //If player wants to move on X and Z axis only
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else{
            transform.Translate(p);
        }

        /*
        //Debug.Log("a" + ((transform.rotation.eulerAngles.x) < 90) + " " +(transform.rotation.eulerAngles.x));
        //Debug.Log("b" + ((transform.rotation.eulerAngles.x) > -90) + " " + FixAngle(transform.rotation.eulerAngles.x))
        Debug.Log(transform.rotation.eulerAngles.x);

        //if (!(transform.rotation.eulerAngles.x < 90 && transform.rotation.eulerAngles.x > -90))
        if(transform.rotation.eulerAngles.x > 89 && transform.rotation.eulerAngles.x < 271)
        {
            Debug.Log("Bad");
            
            if(transform.rotation.eulerAngles.x > 89)
            {
                transform.rotation = Quaternion.Euler( 88, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                Debug.Log("High");
            }
            else if (transform.rotation.eulerAngles.x < 271)
            {
                transform.rotation = Quaternion.Euler(272, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                Debug.Log("Low");
            }

        }
        */

        if(Input.GetKeyDown(KeyCode.U))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
       
    }

    float FixAngle(float a)
    {
        while(a > 360f)
        {
            a -= 360f;
        }

        while (a < 0f)
        {
            a += 360f;
        }

        return a;
    }
     
    private Vector3 GetBaseInput() { //returns the basic values, if it's 0 than it's not active.
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey (KeyCode.W)){
            p_Velocity += new Vector3(0, 0 , 1);
        }
        if (Input.GetKey (KeyCode.S)){
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey (KeyCode.A)){
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey (KeyCode.D)){
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}