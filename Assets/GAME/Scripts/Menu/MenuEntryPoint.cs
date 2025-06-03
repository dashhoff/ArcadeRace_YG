using System.Collections;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    [SerializeField] private SettingsSaves _settingsSaves;
    [SerializeField] private MenuSettings _menuAudio;
    
    [SerializeField] private MenuTracks _menuTracks;
    
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        _settingsSaves.Init();
        _menuAudio.Init();
        _menuTracks.Init();
    }
}
