using System;
using UnityEngine;

public class SettingsSaves : MonoBehaviour
{
    public static SettingsSaves Instance;

    public float GeneralVolume;
    public float EnviromentVolume;
    public float CarVolume;
    public float UIVolume;
    public float MusicVolume;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        Load();
    }

    public void Load()
    {
        GeneralVolume = PlayerPrefs.GetFloat("GeneralVolume", 1);
        EnviromentVolume = PlayerPrefs.GetFloat("EnviromentVolume", 1);
        CarVolume = PlayerPrefs.GetFloat("CarVolume", 1);
        UIVolume = PlayerPrefs.GetFloat("UIVolume", 1);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
    }
    
    public void Save()
    {
        PlayerPrefs.SetFloat("GeneralVolume", GeneralVolume);
        PlayerPrefs.SetFloat("EnviromentVolume", EnviromentVolume);
        PlayerPrefs.SetFloat("CarVolume", CarVolume);
        PlayerPrefs.SetFloat("UIVolume", UIVolume);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
    }
}
