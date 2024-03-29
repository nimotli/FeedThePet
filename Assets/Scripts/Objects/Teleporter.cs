﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField]
    Transform tpTarget;
    [SerializeField]
    float timeToTp = 0.5f;
    AudioSource audioS;
    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("triggered");
        if(collision.tag=="Projectile")
        {
            //tp visual effect and sound
            StartCoroutine(teleport(collision.gameObject));
            audioS.Play();
        }
    }
    IEnumerator teleport(GameObject projectile)
    {
        yield return new WaitForSeconds(timeToTp);
        projectile.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        projectile.transform.position = tpTarget.position;
    }
}
