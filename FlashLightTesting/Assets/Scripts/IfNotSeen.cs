using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfNotSeen : MonoBehaviour {

    public Invokable[] invokables;
    public Camera cameraToCheck;
    public bool enable = false;

    // Use this for initialization
    void Start()
    {
        if (invokables == null)
            invokables = gameObject.GetComponents<Invokable>();
        cameraToCheck = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!enable)
            return;
        Vector3 screenPoint = cameraToCheck.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        if (onScreen)
        {
            RaycastHit hit;
            // Calculate Ray direction
            Vector3 direction = cameraToCheck.transform.position - transform.position;
            if (Physics.Raycast(transform.position, direction, out hit))
            {
                if (hit.collider.tag != "MainCamera") //hit something else before the camera
                {
                    return;
                }
                else
                    foreach (Invokable i in invokables)
                        if (i.enable)
                            i.Invoke();
            }
        }
        else
            foreach (Invokable i in invokables)
                if (i.enable)
                    i.Invoke();
    }
}
