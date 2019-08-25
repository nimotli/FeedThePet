using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    AudioSource audioS;
    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponentInParent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Projectile")
        {
            audioS.Play();
        }
    }
}
