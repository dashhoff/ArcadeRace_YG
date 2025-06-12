using UnityEngine;

public class Gearbox : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private int _gearsNumber = 5;
    [SerializeField] private int _currentGear;

    [SerializeField] private float _gearSwitchOffest = 0.5f;

    [SerializeField] private float[] _gearRations =
    {
        -3f, //reversed
        3.5f, 
        2,1f, 
        1.3f, 
        1.0f, 
        0.75f
    }; //2105
    
    public float GetCurrentGear()
    {
        return _currentGear;
    }
    
    public float GetCurrentGearRatio()
    {
        return _gearRations[_currentGear];
    }

    public void UpGear()
    {
        if (_currentGear != _gearsNumber - 1)
        {
            if (_currentGear != 0)
                _car._engine.SubRPM(Mathf.RoundToInt(_car._engine.GetRPM() * _gearSwitchOffest));
                
            _currentGear++;
        }
    }

    public void DownGear()
    {
        if (_currentGear != 0)
        {
            if (_currentGear != 1)
            {
                _car._engine.AddRPM(Mathf.RoundToInt(_car._engine.GetRPM() * _gearSwitchOffest));
            }
            _currentGear--; 
        }
    } 
}
