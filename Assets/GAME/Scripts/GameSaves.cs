using UnityEngine;
using YG;

public class GameSaves : MonoBehaviour
{
    public static GameSaves Instance;

    public int Money;
    public int[] OpenTracks;
    public int[] OpenCars;
    
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

    public void Init()
    {
        YGLoad();
    }
    
    public void YGLoad()
    {
        Money = YandexGame.savesData.Money;
        OpenTracks = YandexGame.savesData.OpenTracks;
        OpenCars = YandexGame.savesData.OpenCars;
    }

    
    public void YGSave()
    {
        YandexGame.savesData.Money = Money;
        YandexGame.savesData.OpenTracks = OpenTracks;
        YandexGame.savesData.OpenCars = OpenCars;
        
        YandexGame.SaveProgress();
    }
    
    public void Load()
    {
    }
    
    public void Save()
    {
        
        PlayerPrefs.Save();
    }
}
