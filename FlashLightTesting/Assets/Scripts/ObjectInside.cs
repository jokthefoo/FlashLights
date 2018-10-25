using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInside : MonoBehaviour {

    private bool activated = false;
    public string targetName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.name == targetName && !activated)
        {
            Debug.Log("INSIDE CIRCLE!!!");
            activated = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == targetName && activated)
        {
            Debug.Log("LEAVING CIRCLE!!!");
            activated = false;
        }
    }
}
