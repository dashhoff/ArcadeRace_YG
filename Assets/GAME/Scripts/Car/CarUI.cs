using System;
using TMPro;
using UnityEngine;

public class CarUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentGearText;
    [SerializeField] private TMP_Text _currentRpmText;
    [SerializeField] private TMP_Text _currentSpeedText;

    public void UpdateGearText(float newGear)
    {
        if(newGear == 0)
            _currentGearText.text = "R";
        else
            _currentGearText.text = newGear.ToString();
    }
    
    public void UpdateRPMText(float newRPM)
    {
        _currentRpmText.text = newRPM.ToString();
    }
    
    public void UpdateSpeedText(float newSpeed)
    {
        _currentSpeedText.text = newSpeed.ToString();
    }
}
