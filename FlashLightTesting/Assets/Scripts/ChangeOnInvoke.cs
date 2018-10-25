using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOnInvoke : Invokable {

    Transform current;
    public Transform targetTransformation;
    public float alpha = 0;
    public float step = 0.01f;

	// Use this for initialization
	void Start () {
        current = transform;
	}

    public override void Invoke()
    {
        transform.position = Vector3.Lerp(current.position, targetTransformation.position, alpha);
        transform.rotation = Quaternion.Lerp(current.rotation, targetTransformation.rotation, alpha);
        transform.localScale = Vector3.Lerp(current.localScale, targetTransformation.localScale, alpha);
        alpha += step;
        alpha = Mathf.Clamp(alpha, 0, 1);
    }
}
