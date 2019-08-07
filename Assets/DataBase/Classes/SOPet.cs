using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pet", menuName = "Enteties/Pet", order = 1)]
public class SO_Pet : ScriptableObject
{
    public string petName;
    public Sprite petArt;
}
