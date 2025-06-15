
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class MenuCarManager : MonoBehaviour
{
    [SerializeField] private MenuCar[] _cars;
    [SerializeField] private int _currentCar;

    [SerializeField] private GameObject _playButton;
    [SerializeField] private Image _lockImage;
    
    [SerializeField] private TMP_Text _currentCarNameText;
    [SerializeField] private TMP_Text _currentCarInfoText;

    public void Init()
    {
        _currentCar = GameData.Instance.CurrentCar;
        
        SetActiveCar();
        SetTextInfo();
        TrySelectCar();
    }
    
    public void LeftArrow()
    {
        _currentCar--;
        
        if(_currentCar < 0)
            _currentCar = _cars.Length - 1;

        SetActiveCar();
        SetTextInfo();
        TrySelectCar();
    }
    
    public void RightArrow()
    {
        _currentCar++;
        
        if(_currentCar > _cars.Length - 1)
            _currentCar = 0;

        SetActiveCar();
        SetTextInfo();
        TrySelectCar();
    }

    public void SetActiveCar()
    {
        for (int i = 0; i < _cars.Length; i++)
        {
            _cars[i].Model.SetActive(i == _currentCar);
        }
    }

    public void SetTextInfo()
    {
        _currentCarNameText.text = _cars[_currentCar].CarName;
        
        if (YandexGame.lang == "ru")
            _currentCarInfoText.text = _cars[_currentCar].CarRuInfo;
        else
            _currentCarInfoText.text = _cars[_currentCar].CarEnInfo;
    }

    public void TrySelectCar()
    {
        if (GameSaves.Instance.OpenCars[_currentCar] == 1)
        {
            _lockImage.gameObject.SetActive(true);
            _playButton.SetActive(false);
            
            GameData.Instance.SetCar(_currentCar);
        }
        else
        {
            _lockImage.gameObject.SetActive(false);
            _playButton.SetActive(true);
        }
    }
}
