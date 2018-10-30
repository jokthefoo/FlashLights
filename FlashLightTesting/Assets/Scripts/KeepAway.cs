using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepAway : MonoBehaviour {

    GameObject[] objectsToStayAwayFrom;
    public float distance;

	// Use this for initialization
	void Start () {
        objectsToStayAwayFrom = GameObject.FindGameObjectsWithTag("Mannequin");
	}
	
	// Update is called once per frame
	void Update () {
        foreach (GameObject obj in objectsToStayAwayFrom)
        {
            if (obj != gameObject)
            {
                float dist = Vector3.Distance(transform.position, obj.transform.position);
                if(dist < distance)
                {
                    // create a pushback effect
                    Debug.Log(dist);
                    transform.Translate((transform.position - obj.transform.position).normalized);
                }

            }
        }
	}
}
