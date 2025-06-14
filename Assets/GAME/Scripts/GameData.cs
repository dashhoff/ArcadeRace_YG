
using System;
using UnityEngine;

public class GameData : MonoBehaviour 
{
    public static GameData Instance;

    public int CurrentTrack;

    public int CurrentCar;

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
        CurrentTrack = value;
    }
    
    public void SetCar(int value)
    {
        CurrentCar = value;
    }

    public void SetTimeOfDay(int value)
    {
        TimeOfDay = value;
    }
}
