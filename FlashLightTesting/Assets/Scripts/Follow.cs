using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Invokable {

    public GameObject FollowTarget;
    public float FollowSpeed;
    AudioClip scraping;
    AudioSource mannequinSounds;
    GameObject[] objectsToStayAwayFrom;
    public float distance;

    private void Start()
    {
        mannequinSounds = GetComponent<AudioSource>();
        scraping = Resources.Load<AudioClip>("Sounds/Mannequin Slow");
        objectsToStayAwayFrom = GameObject.FindGameObjectsWithTag("Mannequin");
    }

    public override void Invoke()
    {
        // follows a straight-line path for now. Need to add pathfinding with obstacles and stuff?
        float dist = Vector3.Distance(transform.position, FollowTarget.transform.position);
        Vector3 pushback = new Vector3();
        if(dist > 1)
        {
            foreach (GameObject obj in objectsToStayAwayFrom)
            {
                if (obj != gameObject)
                {
                    dist = Vector3.Distance(transform.position, obj.transform.position);
                    if (dist < distance)
                    {
                        pushback += (transform.position - obj.transform.position).normalized;
                    }

                }
            }

            transform.position = Vector3.MoveTowards(transform.position, FollowTarget.transform.position, FollowSpeed) + new Vector3(pushback.x,0,0);
            transform.LookAt(FollowTarget.transform);
            
            if (!mannequinSounds.isPlaying)
                mannequinSounds.PlayOneShot(scraping);
        }
        //Debug.Log("Following");
    }
}
