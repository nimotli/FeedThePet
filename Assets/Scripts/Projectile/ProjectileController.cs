using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    SOProjectile projectileData;
    SpriteRenderer spriteRn;
    private void Start()
    {
        spriteRn = GetComponent<SpriteRenderer>();
        spriteRn.sprite = projectileData.projectileArt;
    }

    
}
