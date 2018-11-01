using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterTrigger : MonoBehaviour {

    public GameObject[] mannies;
    bool triggered = false;

    // Use this for initialization
    void Start () {
        mannies = GameObject.FindGameObjectsWithTag("Mannequin");
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player").transform.position.z > 22.864)
            trigger();

	}

    private void trigger()
    {
        if (triggered)
            return;
        for (int i = 0; i < mannies.Length; i++)
        {
            mannies[i].GetComponent<EnableTrigger>().Invoke();
        }
        triggered = true;
    }
}
