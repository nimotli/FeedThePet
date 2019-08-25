using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private SOProjectile projectileData;
    public bool used = false;
    private void Start()
    {
    }
    public void setProjectileData(SOProjectile projectile)
    {
        projectileData = projectile;
        GetComponent<SpriteRenderer>().sprite =projectile.projectileArt;
    }
    public SOProjectile getProjectileData()
    {
        return projectileData;
    }

    void usedProjectile()
    {
        if (used && gameObject != null)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true;
        }
    }


}
