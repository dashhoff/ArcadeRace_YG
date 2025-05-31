using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    
    [SerializeField] private Slider _generalSlider;
    [SerializeField] private Slider _enviromentSlider;
    [SerializeField] private Slider _carSlider;
    [SerializeField] private Slider _uiSlider;
    [SerializeField] private Slider _musicSlider;

    public void Init()
    {
        LoadSliderValue();
        SetMixerVolume();
    }

    public void SaveValues()
    {
        SettingsSaves.Instance.GeneralVolume = _generalSlider.value;
        SettingsSaves.Instance.EnviromentVolume = _enviromentSlider.value;
        SettingsSaves.Instance.CarVolume = _carSlider.value;
        SettingsSaves.Instance.UIVolume = _uiSlider.value;
        SettingsSaves.Instance.MusicVolume = _musicSlider.value;
        SettingsSaves.Instance.Save();

        SetMixerVolume();
    }
    
    public void LoadSliderValue()
    {
        _generalSlider.value = SettingsSaves.Instance.GeneralVolume;
        _enviromentSlider.value = SettingsSaves.Instance.EnviromentVolume;
        _carSlider.value = SettingsSaves.Instance.CarVolume;
        _uiSlider.value = SettingsSaves.Instance.UIVolume;
        _musicSlider.value = SettingsSaves.Instance.MusicVolume;
    }

    public void SetMixerVolume()
    {
        _audioMixer.SetFloat("Master", ToDecibel(SettingsSaves.Instance.GeneralVolume));
        _audioMixer.SetFloat("Enviroment", ToDecibel(SettingsSaves.Instance.EnviromentVolume));
        _audioMixer.SetFloat("Car", ToDecibel(SettingsSaves.Instance.CarVolume));
        _audioMixer.SetFloat("UI", ToDecibel(SettingsSaves.Instance.UIVolume));
        _audioMixer.SetFloat("Music", ToDecibel(SettingsSaves.Instance.MusicVolume));
    }
    
    private float ToDecibel(float value) => Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f)) * 20f;
}
