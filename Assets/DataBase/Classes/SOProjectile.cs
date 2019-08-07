using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Projectile", menuName = "Enteties/Projectile", order = 1)]
public class SOProjectile : ScriptableObject
{
    public string projectileName;
    public Sprite projectileArt;
    public int type;
}
