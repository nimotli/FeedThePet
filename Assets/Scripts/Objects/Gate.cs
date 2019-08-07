using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : TriggerObject
{
     override
    public void activate()
    {
        gameObject.SetActive(false);
    }
}
