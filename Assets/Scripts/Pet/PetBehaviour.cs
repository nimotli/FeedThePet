using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetBehaviour : MonoBehaviour
{
    SpriteRenderer spriteRn;
    GameManeger gameManager;
    Animator petAnim;
    [SerializeField]
    SO_Pet petData;
    Collider2D petCol;
    bool wasFed = false;
    void Start()
    {
        petCol = GetComponent<Collider2D>();
        petAnim = GetComponent<Animator>();
        gameManager = GameManeger.instance;
        spriteRn = GetComponentInChildren<SpriteRenderer>();
        spriteRn.sprite = petData.petArt;
        GameEvents.instance.onFeed += feedPet;
    }

    public void feedPet()
    {
        if(wasFed)
        {
            petAnim.SetBool("Fed", true);
            petCol.enabled = false;
        }
       
    }
    public void setFedFalse()
    {
        petAnim.SetBool("Fed", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ProjectileController pc = collision.gameObject.GetComponent<ProjectileController>();
        if (collision.gameObject.tag == "Projectile" && pc.getProjectileData().type==0)
        {
            pc.used = true;
            wasFed = true;
            Destroy(collision.gameObject);
            GameEvents.instance.feed();
        }
    }
}
