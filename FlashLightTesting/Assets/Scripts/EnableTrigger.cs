using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableTrigger : Invokable {

    public override void Invoke()
    {
        GetComponent<Follow>().enable = true;
        GetComponent<IfNotSeen>().enable = true;
        enable = false;
    }
}
