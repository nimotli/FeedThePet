using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound Collection", menuName = "Enteties/Sound Collection", order = 1)]
public class SOSoundEffectCollection : ScriptableObject
{
    public List<SOSoundEffect> sounds;
}

