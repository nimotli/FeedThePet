using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelProjectile", menuName = "Enteties/LevelProjectile", order = 1)]
public class SOProjectilesInLevel : ScriptableObject
{
    public SOProjectile projectile;
    public int number;
}
