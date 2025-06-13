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
    
    [SerializeField] private AnimationCurve[] _gearRationsStrenght;
    
    public float GetCurrentGear()
    {
        return _currentGear;
    }
    
    public float GetCurrentGearRatio()
    {
        float ratio = _gearRations[_currentGear];
        
        Debug.Log("Ratio: " + ratio);
        
        return ratio;
    }
    
    public float GetCurrentGearRatioStrenght()
    {
        float normalizedRPM = Mathf.InverseLerp(0, _car._engine.GetMaxRPM(), _car._engine.GetRPM());
        float ratioStrenght = _gearRationsStrenght[_currentGear].Evaluate(normalizedRPM);
        
        Debug.Log("RatioStrenght: " + ratioStrenght);
        
        return ratioStrenght;
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
