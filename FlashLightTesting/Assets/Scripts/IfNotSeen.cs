using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfNotSeen : MonoBehaviour {

    Invokable invokable;
    public Camera cameraToCheck;

	// Use this for initialization
	void Start () {
        invokable = gameObject.GetComponent<Invokable>();
        cameraToCheck = FindObjectOfType<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 screenPoint = cameraToCheck.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        if (!onScreen)
            invokable.Invoke();
    }
}
