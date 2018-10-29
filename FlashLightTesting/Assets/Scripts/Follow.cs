using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Invokable {

    public GameObject FollowTarget;
    public float FollowSpeed;

    public override void Invoke()
    {
        // follows a straight-line path for now. Need to add pathfinding with obstacles and stuff?
        transform.position = Vector3.MoveTowards(transform.position, FollowTarget.transform.position, FollowSpeed);
        Debug.Log("Following");
    }
}
