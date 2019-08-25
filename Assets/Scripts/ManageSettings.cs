using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageSettings : MonoBehaviour
{
    [SerializeField]
    SOSettings settings;

    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        GameEvents.instance.onChangeSettings += setMusic;
        setMusic();
    }

    void setMusic()
    {
        source.volume = settings.music;
    }
}
