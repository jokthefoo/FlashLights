using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public Light yellowLight;
    public Light blueLight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.W))
        {
            blueLight.transform.position = new Vector3(blueLight.transform.position.x, blueLight.transform.position.y +.1f, blueLight.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            blueLight.transform.position = new Vector3(blueLight.transform.position.x - .1f, blueLight.transform.position.y, blueLight.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            blueLight.transform.position = new Vector3(blueLight.transform.position.x, blueLight.transform.position.y - .1f, blueLight.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            blueLight.transform.position = new Vector3(blueLight.transform.position.x  + .1f, blueLight.transform.position.y, blueLight.transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            yellowLight.transform.position = new Vector3(yellowLight.transform.position.x, yellowLight.transform.position.y + .1f, yellowLight.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            yellowLight.transform.position = new Vector3(yellowLight.transform.position.x - .1f, yellowLight.transform.position.y, yellowLight.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            yellowLight.transform.position = new Vector3(yellowLight.transform.position.x, yellowLight.transform.position.y - .1f, yellowLight.transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            yellowLight.transform.position = new Vector3(yellowLight.transform.position.x + .1f, yellowLight.transform.position.y, yellowLight.transform.position.z);
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            if(blueLight.intensity == 0)
            {
                blueLight.intensity = 1;
            }
            else
            {
                blueLight.intensity = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (yellowLight.intensity == 0)
            {
                yellowLight.intensity = 1;
            }
            else
            {
                yellowLight.intensity = 0;
            }
        }



        if (Valve.VR.SteamVR_Input._default.inActions.GrabGrip.GetStateDown(Valve.VR.SteamVR_Input_Sources.RightHand) ||
            Valve.VR.SteamVR_Input._default.inActions.GrabGrip.GetStateUp(Valve.VR.SteamVR_Input_Sources.RightHand))
        {
            if (blueLight.intensity == 0)
            {
                blueLight.intensity = 5;
            }
            else
            {
                blueLight.intensity = 0;
            }
        }
        if (Valve.VR.SteamVR_Input._default.inActions.GrabGrip.GetStateDown(Valve.VR.SteamVR_Input_Sources.LeftHand) ||
            Valve.VR.SteamVR_Input._default.inActions.GrabGrip.GetStateUp(Valve.VR.SteamVR_Input_Sources.LeftHand))
        {
            if (yellowLight.intensity == 0)
            {
                yellowLight.intensity = 5;
            }
            else
            {
                yellowLight.intensity = 0;
            }
        }
    }
}
