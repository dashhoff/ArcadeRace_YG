using System;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private Wheel[] _wheels;
    [SerializeField] private Wheel[] _drivingWheels;
    [SerializeField] private Wheel[] _frontWheels;
    
    [SerializeField] private Rigidbody _rb;
    
    [SerializeField] private AnimationCurve _steeringCurve;

    public Engine _engine;
    public Gearbox _gearbox;
    public CarUI _carUI;

    private void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {
        Acceleration(CalculateTorque());
    }

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        _carUI.UpdateRPMText(_engine.GetRPM());
        _carUI.UpdateGearText(_gearbox.GetCurrentGear());
        _carUI.UpdateSpeedText(Mathf.Round(_rb.linearVelocity.magnitude * 5));
    }
    
    public void Init()
    {
        for (int i = 0; i < _wheels.Length; i++)
        {
            _wheels[i].SetCarRb(_rb);
            _wheels[i].SetDriveTire(false);
        }

        for (int i = 0; i < _drivingWheels.Length; i++)
        {
            _drivingWheels[i].SetDriveTire(true);
        }
    }

    public float CalculateTorque()
    {
        return _engine.GetTorque() / _gearbox.GetCurrentGearRatio();
    }

    public void Acceleration(float torque)
    {
        for (int i = 0; i < _drivingWheels.Length; i++)
        {
            _drivingWheels[i].Acceleration(torque);
        }
    }
    
    public void SetAcceleration(float acceleration)
    {
        _engine.SetInput(acceleration);
    }

    public void RotateFrontWheel(float angle)
    {
        float carSpeed = _rb.linearVelocity.magnitude;
        float steering = _steeringCurve.Evaluate(carSpeed);
        
        for (int i = 0; i < _frontWheels.Length; i++)
        {
            Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
            _frontWheels[i].transform.localRotation = Quaternion.Lerp(
                _frontWheels[i].transform.localRotation,
                targetRotation,
                Time.deltaTime * steering);
        }
    }
}
