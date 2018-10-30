using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Invokable {

    public GameObject FollowTarget;
    public float FollowSpeed;
    AudioClip scraping;
    AudioSource mannequinSounds;

    private void Start()
    {
        mannequinSounds = GetComponent<AudioSource>();
        scraping = Resources.Load<AudioClip>("Sounds/Mannequin Slow");
    }

    public override void Invoke()
    {
        // follows a straight-line path for now. Need to add pathfinding with obstacles and stuff?
        float dist = Vector3.Distance(transform.position, FollowTarget.transform.position);
        if(dist > 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, FollowTarget.transform.position, FollowSpeed);
            if (!mannequinSounds.isPlaying)
                mannequinSounds.PlayOneShot(scraping);
        }
        //Debug.Log("Following");
    }
}
