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

    public void Init()
    {
        LoadSlidersValue();
    }

    public void OnGeneralSliderChanged()
    {
        SettingsSaves.Instance.GeneralVolume = _generalSlider.value;
        SettingsSaves.Instance.YGSave();
        
        _audioMixer.SetFloat("Master", ToDecibel(_generalSlider.value));
    }

    public void OnEnviromentSliderChanged()
    {
        SettingsSaves.Instance.EnviromentVolume = _enviromentSlider.value;
        SettingsSaves.Instance.YGSave();

        _audioMixer.SetFloat("Enviroment", ToDecibel(_enviromentSlider.value));
    }

    public void OnCarSliderChanged()
    {
        SettingsSaves.Instance.CarVolume = _carSlider.value;
        SettingsSaves.Instance.YGSave();

        _audioMixer.SetFloat("Car", ToDecibel(_carSlider.value));
    }

    public void OnUISliderChanged()
    {
        SettingsSaves.Instance.UIVolume = _uiSlider.value;
        SettingsSaves.Instance.YGSave();

        _audioMixer.SetFloat("UI", ToDecibel(_uiSlider.value));
    }

    public void OnMusicSliderChanged()
    {
        SettingsSaves.Instance.MusicVolume = _musicSlider.value;
        SettingsSaves.Instance.YGSave();

        _audioMixer.SetFloat("Music", ToDecibel(_musicSlider.value));
    }
    
    public void OnGeneralGraphicSliderChanged()
    {
        SettingsSaves.Instance.GraphicsPreset = Mathf.RoundToInt(_generalGraphicSlider.value);
        SettingsSaves.Instance.YGSave();

        
        QualitySettings.SetQualityLevel(SettingsSaves.Instance.GraphicsPreset);
    }
    
    public void LoadSlidersValue()
    {
        _generalSlider.value = SettingsSaves.Instance.GeneralVolume;
        _enviromentSlider.value = SettingsSaves.Instance.EnviromentVolume;
        _carSlider.value = SettingsSaves.Instance.CarVolume;
        _uiSlider.value = SettingsSaves.Instance.UIVolume;
        _musicSlider.value = SettingsSaves.Instance.MusicVolume;

        _generalGraphicSlider.value = SettingsSaves.Instance.GraphicsPreset;
    }

    private float ToDecibel(float value) => Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
}