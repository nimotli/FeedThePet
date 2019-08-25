using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject options;
    [SerializeField]
    GameObject levels;
    [SerializeField]
    GameObject credit;
    [SerializeField]
    GameObject main;
    [SerializeField]
    AudioClip open;
    [SerializeField]
    AudioClip close;
    [SerializeField]
    AudioClip zap;
    [SerializeField]
    SOSettings settings;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }
    public void playOpenSound()
    {
        source.clip = open;
        source.Play();
    }
    public void playCloseSound()
    {
        source.clip = close;
        source.Play();
    }
    public void playSlider()
    {
        source.clip = zap;
        source.Play();
    }
    public void exitLevelHolder()
    {
        levels.SetActive(false);
        options.SetActive(false);
        credit.SetActive(false);
        main.SetActive(true);
        playCloseSound();
    }
    public void exitOptions()
    {
        levels.SetActive(false);
        options.SetActive(false);
        credit.SetActive(false);
        main.SetActive(true);
        playCloseSound();
    }
    public void exitCredit()
    {
        levels.SetActive(false);
        options.SetActive(false);
        credit.SetActive(false);
        main.SetActive(true);
        playCloseSound();
    }
    public void showOptions()
    {
        levels.SetActive(false);
        options.SetActive(true);
        credit.SetActive(false);
        main.SetActive(false);
        playOpenSound();
    }
    public void showLevelHolder()
    {
        levels.SetActive(true);
        options.SetActive(false);
        credit.SetActive(false);
        main.SetActive(false);
        playOpenSound();
    }
    public void showCredit()
    {
        levels.SetActive(false);
        options.SetActive(false);
        credit.SetActive(true);
        main.SetActive(false);
        playOpenSound();
    }

    public void changeMusicVolume(Slider slider)
    {
        settings.music = slider.value/slider.maxValue;
        GameEvents.instance.changeSettings();
    }
    public void changeSoundVolume(Slider slider)
    {
        settings.sound = slider.value / slider.maxValue;
        GameEvents.instance.changeSettings();
    }
}
