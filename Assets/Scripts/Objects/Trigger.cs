using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    [SerializeField]
    Color triggeredColor;
    [SerializeField]
    TriggerObject objectToTrigger;
    bool triggered = false;
    SpriteRenderer sr;
    AudioSource audioS;
    Animator trigAnimator;
    private void Start()
    {
        trigAnimator = GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
        sr = this.GetComponentInChildren<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile" && !triggered)
        {
            objectToTrigger.activate();
            //sr.color = triggeredColor;
            triggered = true;
            audioS.Play();
            trigAnimator.SetTrigger("Triggered");
        }
    }
}
