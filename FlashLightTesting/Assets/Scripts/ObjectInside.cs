using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInside : MonoBehaviour
{

    private bool activated = false;
    public string targetName;
    private static int activations = 0;

    AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (activations == 1)
        {
            //Debug.Log("You Win!!");
            Destroy(GameObject.Find("FinalDoor"));
            activations = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == targetName && !activated)
        {
            other.transform.parent.GetComponent<Follow>().FollowSpeed = 0;
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = true;
            activations++;
            //Debug.Log("INSIDE CIRCLE!!!");
            activated = true;

            if (audioSource != null)
                audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == targetName && activated)
        {
            other.transform.parent.GetComponent<Follow>().FollowSpeed = 0.01f;
            other.transform.parent.GetComponent<Rigidbody>().isKinematic = false;
            activations--;
            //Debug.Log("LEAVING CIRCLE!!!");
            activated = false;
        }
    }
}
