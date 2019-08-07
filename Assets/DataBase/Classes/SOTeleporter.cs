using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Teleporter", menuName = "Enteties/Teleporter", order = 1)]
public class SOTeleporter : ScriptableObject
{
    public string teleporterName;
    public Sprite teleporterArt;
    public float timeToTp;
}
