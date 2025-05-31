using Unity.VisualScripting;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField] private SettingsSaves _settingsSaves;
    [SerializeField] private MenuAudio _menuAudio;
    
    private void Start()
    {
        Application.targetFrameRate = 360;
        
        _settingsSaves.Init();
        _menuAudio.Init();
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
