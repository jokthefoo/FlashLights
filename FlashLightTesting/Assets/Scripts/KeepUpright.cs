﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepUpright : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void keepUpright()
    {
        transform.rotation = Quaternion.Euler(0,transform.rotation.y,0);
    }
}
