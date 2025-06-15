using System;
using UnityEngine;
using YG;

public class SettingsSaves : MonoBehaviour
{
    public static SettingsSaves Instance;

    [Header("Audio")]
    public float GeneralVolume;
    public float EnviromentVolume;
    public float CarVolume;
    public float UIVolume;
    public float MusicVolume;
    
    [Header("Graphics")]
    public int GraphicsPreset;
    
    private void Awake()
    {
        Instance = this;
    }

    public void Init()
    {
        YGLoad();
    }
    
    public void YGLoad()
    {
        GeneralVolume = YandexGame.savesData.GeneralVolume;
        EnviromentVolume = YandexGame.savesData.EnviromentVolume;
        CarVolume = YandexGame.savesData.CarVolume;
        UIVolume = YandexGame.savesData.UIVolume;
        MusicVolume = YandexGame.savesData.MusicVolume;

        GraphicsPreset = YandexGame.savesData.GraphicsPreset;
    }
    
    public void YGSave()
    {
        YandexGame.savesData.GeneralVolume = GeneralVolume;
        YandexGame.savesData.EnviromentVolume = EnviromentVolume;
        YandexGame.savesData.CarVolume = CarVolume;
        YandexGame.savesData.UIVolume = UIVolume;
        YandexGame.savesData.MusicVolume = MusicVolume;
        
        YandexGame.savesData.GraphicsPreset = GraphicsPreset;
        
        YandexGame.SaveProgress();
    }

    public void Load()
    {
        GeneralVolume = PlayerPrefs.GetFloat("GeneralVolume", 1);
        EnviromentVolume = PlayerPrefs.GetFloat("EnviromentVolume", 1);
        CarVolume = PlayerPrefs.GetFloat("CarVolume", 1);
        UIVolume = PlayerPrefs.GetFloat("UIVolume", 1);
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1);
        
        GraphicsPreset = PlayerPrefs.GetInt("GraphicsPreset", 1);
    }
    
    public void Save()
    {
        PlayerPrefs.SetFloat("GeneralVolume", GeneralVolume);
        PlayerPrefs.SetFloat("EnviromentVolume", EnviromentVolume);
        PlayerPrefs.SetFloat("CarVolume", CarVolume);
        PlayerPrefs.SetFloat("UIVolume", UIVolume);
        PlayerPrefs.SetFloat("MusicVolume", MusicVolume);
        
        PlayerPrefs.SetInt("GraphicsPreset", GraphicsPreset);
        
        PlayerPrefs.Save();
    }
}
