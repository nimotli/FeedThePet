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
    void Start()
    {
        petCol = GetComponent<Collider2D>();
        petAnim = GetComponent<Animator>();
        gameManager = GameManeger.instance;
        spriteRn = GetComponentInChildren<SpriteRenderer>();
        spriteRn.sprite = petData.petArt;
    }
    
    public void feedPet()
    {
        petAnim.SetBool("Fed", true);
        petCol.enabled = false;
    }
    public void setFedFalse()
    {
        petAnim.SetBool("Fed", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            feedPet();
        }
    }
}
