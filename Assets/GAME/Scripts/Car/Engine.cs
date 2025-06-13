using System;
using UnityEngine;

public enum EngineLayout
{
    Inline4,
    Inline5,
    Inline6,
    V4,
    V6,
    V8,
    Opposed,
    Rotary
}

public enum Boost
{
    None,
    Supercharger,
    Turbine
}

public class Engine : MonoBehaviour
{
    [SerializeField] private Gearbox _gearbox;
    [SerializeField] private EngineLayout _engineLayout = EngineLayout.Inline4;
    [SerializeField] private Boost _boost = Boost.None;

    [SerializeField] private int _maxRPM;
    [SerializeField] private int _currentRPM;
    [SerializeField] private AnimationCurve _RPMAccelerationCurve;
    //[SerializeField] private int _RPMAcceleration;
    //[SerializeField] private int _RPMDeceleration;
    
    [SerializeField] private AnimationCurve _torqueCurve;
    [SerializeField] private float _torqueOffset;

    public int GetMaxRPM() => _maxRPM;
    public int GetRPM() => _currentRPM;

    public void AddRPM(int value)
    {
        _currentRPM += value;
        if (_currentRPM > _maxRPM)
            _currentRPM = _maxRPM;
    }
    
    public void SubRPM(int value)
    {
        _currentRPM -= value;
        if (_currentRPM < 0)
            _currentRPM = 0;
    }
    
    public float GetTorque()
    {
        float normalizedRPM = Mathf.InverseLerp(0, _maxRPM, _currentRPM);
        float torque = _torqueCurve.Evaluate(normalizedRPM) * _torqueOffset * _gearbox.GetCurrentGearRatioStrenght();
        
        //Debug.Log("Torque: " + torque);
        
        return torque;
    }

    public void Acceleration(float acceleration)
    {
        float normalizedRPM = Mathf.InverseLerp(0, _maxRPM, _currentRPM);

        if (_gearbox.GetCurrentGearRatio() < 0)
            _currentRPM += Mathf.RoundToInt(_RPMAccelerationCurve.Evaluate(normalizedRPM) * -1 * _gearbox.GetCurrentGearRatio());
        else
            _currentRPM += Mathf.RoundToInt(_RPMAccelerationCurve.Evaluate(normalizedRPM) * _gearbox.GetCurrentGearRatio());
        
        if (_currentRPM >= _maxRPM)
        {
            _currentRPM = _maxRPM;
            return;
        }

        if (_currentRPM < 0)
        {
            _currentRPM = 0;
            return;
        }
    }
    
    public void SetInput(float acceleration)
    {
        float normalizedRPM = Mathf.InverseLerp(0, _maxRPM, _currentRPM);
        
        if (acceleration != 0 ) Acceleration(acceleration);
        else
        {
            if (_gearbox.GetCurrentGear() != 0)
                _currentRPM = Mathf.RoundToInt(Mathf.Max(0, _currentRPM - _RPMAccelerationCurve.Evaluate(normalizedRPM) * _gearbox.GetCurrentGearRatio()));
            else
                _currentRPM = Mathf.RoundToInt(Mathf.Max(0, _currentRPM + _RPMAccelerationCurve.Evaluate(normalizedRPM) * _gearbox.GetCurrentGearRatio()));
        }
    }
}
