using System;
using TMPro;
using UnityEngine;

public class CarUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentGearText;
    [SerializeField] private TMP_Text _currentRpmText;

    public void UpdateGearText(float newGear)
    {
        _currentGearText.text = newGear.ToString();
    }
    
    public void UpdateRPMText(float newRPM)
    {
        _currentRpmText.text = newRPM.ToString();
    }
}
