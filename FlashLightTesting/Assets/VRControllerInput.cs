using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class VRControllerInput : MonoBehaviour {

    //Should only ever be one, but just in case
    protected List<PickupObject> heldObjects;

    //Controller References
    protected PickupObject trackedObj;
    /*
    public SteamVR_Controller.Device device
    {
        get
        {
            return SteamVR_Controller.Input((int)trackedObj.index);
        }
    }*/

    void Awake()
    {
        //Instantiate lists
        trackedObj = GetComponent<PickupObject>();
        heldObjects = new List<PickupObject>();
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        /*
        if (heldObjects.Count > 0)
        {
            //If trigger is releasee
            if (device.GetPressUp(EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                //Release any held objects
                for (int i = 0; i < heldObjects.Count; i++)
                {
                    heldObjects[i].Release(this);
                }
                heldObjects = new List<PickupObject>();
            }
        }*/
    }

    void OnTriggerStay(Collider collider)
    {
        //If object is an interactable item
        PickupObject interactable = collider.GetComponent<PickupObject>();
        if (interactable != null)
        {
            /*
            //If trigger button is down
            if (device.GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger))
            {
                //Pick up object
                interactable.Pickup(this);
                heldObjects.Add(interactable);
            }*/
        }
    }
}
