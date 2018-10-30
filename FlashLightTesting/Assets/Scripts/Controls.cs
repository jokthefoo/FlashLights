using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public Light yellowLight;
    public Light blueLight;
    private float lightIntensity;
    AudioClip flashlightOn, flashlightOff, flashlightPunishment;
    public AudioSource audioSource;
    public AudioSource FL_BG;

	// Use this for initialization
	void Start () {
        lightIntensity = yellowLight.intensity;
        flashlightOn = Resources.Load<AudioClip>("Sounds/Turn FL On");
        flashlightOff = Resources.Load<AudioClip>("Sounds/Turn FL Off");
        flashlightPunishment = Resources.Load<AudioClip>("Sounds/Flashlight On Punishment");
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
                audioSource.panStereo = 0.5f;
                audioSource.PlayOneShot(flashlightOn);
            }
            else
            {
                blueLight.intensity = 0;
                audioSource.panStereo = 0.5f;
                audioSource.PlayOneShot(flashlightOff);
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (yellowLight.intensity == 0)
            {
                yellowLight.intensity = 1;
                audioSource.panStereo = -0.5f;
                audioSource.PlayOneShot(flashlightOn);
            }
            else
            {
                yellowLight.intensity = 0;
                audioSource.panStereo = -0.5f;
                audioSource.PlayOneShot(flashlightOff);
            }
        }



        if (Valve.VR.SteamVR_Input._default.inActions.GrabGrip.GetStateDown(Valve.VR.SteamVR_Input_Sources.RightHand) ||
            Valve.VR.SteamVR_Input._default.inActions.GrabGrip.GetStateUp(Valve.VR.SteamVR_Input_Sources.RightHand))
        {
            if (blueLight.intensity == 0)
            {
                blueLight.intensity = lightIntensity;
                audioSource.panStereo = 0.5f;
                audioSource.PlayOneShot(flashlightOn);
            }
            else
            {
                blueLight.intensity = 0;
                audioSource.panStereo = 0.5f;
                if (FL_BG.isPlaying)
                    FL_BG.Pause();
                audioSource.PlayOneShot(flashlightOff);
            }
        }
        if (Valve.VR.SteamVR_Input._default.inActions.GrabGrip.GetStateDown(Valve.VR.SteamVR_Input_Sources.LeftHand) ||
            Valve.VR.SteamVR_Input._default.inActions.GrabGrip.GetStateUp(Valve.VR.SteamVR_Input_Sources.LeftHand))
        {
            if (yellowLight.intensity == 0)
            {
                yellowLight.intensity = lightIntensity;
                audioSource.panStereo = -0.5f;
                audioSource.PlayOneShot(flashlightOn);
            }
            else
            {
                yellowLight.intensity = 0;
                audioSource.panStereo = -0.5f;
                if (FL_BG.isPlaying)
                    FL_BG.Pause();
                audioSource.PlayOneShot(flashlightOff);
            }
        }

        if(yellowLight.intensity == lightIntensity && blueLight.intensity == lightIntensity)
        {
            FL_BG.PlayOneShot(flashlightPunishment);
        }
    }
}
