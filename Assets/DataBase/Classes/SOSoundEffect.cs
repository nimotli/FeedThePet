using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SFX", menuName = "Enteties/SFX", order = 1)]
public class SOSoundEffect : ScriptableObject
{
    public string seName;
    public AudioClip audio;
}
