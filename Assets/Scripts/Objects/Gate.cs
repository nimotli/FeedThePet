using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : TriggerObject
{
    Animator gateAnim;
    private void Start()
    {
        gateAnim = GetComponent<Animator>();
    }
    override
    public void activate()
    {
        gateAnim.SetTrigger("Triggered");
        //gameObject.SetActive(false);
    }
}
