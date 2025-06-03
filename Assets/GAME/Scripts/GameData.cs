
using System;
using UnityEngine;

public class GameData : MonoBehaviour 
{
    public static GameData Instance;

    public int Track;

    public int TimeOfDay;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    
    public void SetTrack(int value)
    {
        Track = value;
    }

    public void SetTimeOfDay(int value)
    {
        TimeOfDay = value;
    }
}
