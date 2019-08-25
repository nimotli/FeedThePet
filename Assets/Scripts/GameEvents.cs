using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class GameEvents : MonoBehaviour
{

    public static GameEvents instance;

    public event Action onSwitchEvent;
    public event Action onStartingLevel;
    public event Action onRefreshUi;
    public event Action onChangeProjectile;
    public event Action onThrowing;
    public event Action onThrowFinished;
    public event Action onFailed;
    public event Action onFeed;
    public event Action onChangeSettings;
    public void switchEvent()
    {
        if (onSwitchEvent != null)
        {
            onSwitchEvent();
        }
    }
    public void startingLevel()
    {
        if (onStartingLevel != null)
        {
            onStartingLevel();
        }
    }
    public void refreshUi()
    {
        if (onRefreshUi != null)
        {
            onRefreshUi();
        }
    }
    public void changeProjectile()
    {
        if (onChangeProjectile != null)
        {
            onChangeProjectile();
        }
    }
    public void throwing()
    {
        if (onThrowing != null)
        {
            onThrowing();
        }
    }
    public void throwFinish()
    {
        if (onThrowFinished != null)
        {
            onThrowFinished();
        }
    }
    public void failed()
    {
        if (onFailed != null)
        {
            onFailed();
        }
    }
    public void feed()
    {
        if (onFeed != null)
        {
            onFeed();
        }
    }
    public void changeSettings()
    {
        if (onChangeSettings != null)
        {
            onChangeSettings();
        }
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}
