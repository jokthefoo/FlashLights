using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInside : MonoBehaviour {

    private bool activated = false;
    public string targetName;
    private static int activations = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(activations == 3)
        {
            Debug.Log("You Win!!");
        }
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == targetName && !activated)
        {
            other.transform.parent.GetComponent<Follow>().FollowSpeed = 0;
            activations++;
            //Debug.Log("INSIDE CIRCLE!!!");
            activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == targetName && activated)
        {
            other.transform.parent.GetComponent<Follow>().FollowSpeed = 0.01f;
            activations--;
            //Debug.Log("LEAVING CIRCLE!!!");
            activated = false;
        }
    }
}
