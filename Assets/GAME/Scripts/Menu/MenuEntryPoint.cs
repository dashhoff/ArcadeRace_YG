using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MenuEntryPoint : MonoBehaviour
{
    [SerializeField] private SettingsSaves _settingsSaves;
    [SerializeField] private GameSaves _gameSaves;
    
    [SerializeField] private MenuSettings _menuAudio;
    
    [SerializeField] private MenuTracks _menuTracks;
    [SerializeField] private MenuCarManager _menuCarManager;
    
    private void Start()
    {
        Init();
    }

    public void Init()
    {
        ScreenFader.Instance.FadeOut();
        
        _settingsSaves.Init();
        _gameSaves.Init();
        
        _menuAudio.Init();
        
        _menuTracks.Init();
        _menuCarManager.Init();
    }
}
