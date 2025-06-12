using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuSettings : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] private AudioMixer _audioMixer;
    
    [SerializeField] private Slider _generalSlider;
    [SerializeField] private Slider _enviromentSlider;
    [SerializeField] private Slider _carSlider;
    [SerializeField] private Slider _uiSlider;
    [SerializeField] private Slider _musicSlider;
    
    [Header("Graphics")]
    [SerializeField] private Slider _generalGraphicSlider;
    [SerializeField] private Slider _enviromentGraphicSlider;
    //[SerializeField] private Slider _antiAliasingSlider;

    public void Init()
    {
        LoadSlidersValue();
    }

    public void OnGeneralSliderChanged()
    {
        SettingsSaves.Instance.GeneralVolume = _generalSlider.value;
        SettingsSaves.Instance.Save();
        _audioMixer.SetFloat("Master", ToDecibel(_generalSlider.value));
    }

    public void OnEnviromentSliderChanged()
    {
        SettingsSaves.Instance.EnviromentVolume = _enviromentSlider.value;
        SettingsSaves.Instance.Save();
        _audioMixer.SetFloat("Enviroment", ToDecibel(_enviromentSlider.value));
    }

    public void OnCarSliderChanged()
    {
        SettingsSaves.Instance.CarVolume = _carSlider.value;
        SettingsSaves.Instance.Save();
        _audioMixer.SetFloat("Car", ToDecibel(_carSlider.value));
    }

    public void OnUISliderChanged()
    {
        SettingsSaves.Instance.UIVolume = _uiSlider.value;
        SettingsSaves.Instance.Save();
        _audioMixer.SetFloat("UI", ToDecibel(_uiSlider.value));
    }

    public void OnMusicSliderChanged()
    {
        SettingsSaves.Instance.MusicVolume = _musicSlider.value;
        SettingsSaves.Instance.Save();
        _audioMixer.SetFloat("Music", ToDecibel(_musicSlider.value));
    }
    
    public void OnGeneralGraphicSliderChanged()
    {
        SettingsSaves.Instance.GraphicsPreset = Mathf.RoundToInt(_generalGraphicSlider.value);
        SettingsSaves.Instance.Save();
        
        QualitySettings.SetQualityLevel(SettingsSaves.Instance.GraphicsPreset);
    }

    public void OnEnviromentGraphicSliderChanged()
    {
        SettingsSaves.Instance.EnviromentPreset = Mathf.RoundToInt(_enviromentGraphicSlider.value);
        SettingsSaves.Instance.Save();
        
        
    }
    
    /*public void OnAntiAliasingSliderChanged() 
    {
            SettingsSaves.Instance.AntiAliasingPreset = Mathf.RoundToInt(_antiAliasingSlider.value);
            SettingsSaves.Instance.Save();

            switch (SettingsSaves.Instance.AntiAliasingPreset)
            {
                case 0:
                    QualitySettings.antiAliasing = 0;
                    break;
                case 1:
                    QualitySettings.antiAliasing = 2;
                    break;
                case 2:
                    QualitySettings.antiAliasing = 4;
                    break;
                case 3:
                    QualitySettings.antiAliasing = 8;
                    break;
            }
    }*/

    public void LoadSlidersValue()
    {
        _generalSlider.value = SettingsSaves.Instance.GeneralVolume;
        _enviromentSlider.value = SettingsSaves.Instance.EnviromentVolume;
        _carSlider.value = SettingsSaves.Instance.CarVolume;
        _uiSlider.value = SettingsSaves.Instance.UIVolume;
        _musicSlider.value = SettingsSaves.Instance.MusicVolume;

        _generalGraphicSlider.value = SettingsSaves.Instance.GraphicsPreset;
        _enviromentGraphicSlider.value = SettingsSaves.Instance.EnviromentPreset;
        
        //_antiAliasingSlider.value = SettingsSaves.Instance.AntiAliasingPreset;
    }

    private float ToDecibel(float value) => Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
}