using System;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private Rigidbody _carRb;

    [Header("Suspension")]
    [SerializeField] private float _springLenght;
    [SerializeField] private float _springStrength;
    [SerializeField] private float _springDamping;
    
    [SerializeField] private float _tireModelRadius;

    [Header("Side slip")] 
    [SerializeField] private bool _isDrifting = false;
    [SerializeField] private AnimationCurve _sideSlipCurve;
    [SerializeField] private float _sideSlipStrength = 1;
    [SerializeField] private float _sideSlipDetection;
    [SerializeField] private float _finalSlipStrength;
    
    private Dictionary<string, float> _surfaceFriction = new()
    {
        { "Asphalt", 0.7f },
        { "Gravel", 0.5f },
        { "Dirt", 0.3f },
        { "Snow", 0.15f },
        { "Ice", 0.05f },
        {"Other", 0.7f}
    };
    
    [Header("Other")] 
    [SerializeField] private bool _isGrounded;
    
    [SerializeField] private GameObject _tireModel;
    
    [SerializeField] private float _tireMass;
    
    [SerializeField] private bool _isDriveTire;

    [SerializeField] private float _tireXStartRotation;
    [SerializeField] private float _tireYStartRotation;
    [SerializeField] private float _tireZStartRotation;

    private void Start()
    {
       //_tireXStartRotation = _tireModel.transform.localRotation.x;
       //_tireYStartRotation = _tireModel.transform.localRotation.y;
       //_tireZStartRotation = _tireModel.transform.localRotation.z;
    }

    private void FixedUpdate()
    {
        Suspension();
        SurfaceDetection();
        SlipDetection();
        SideSlip();
        
        //RollingResistance();
    }

    private void Suspension()
    {
        _isGrounded = false;
        
        Ray tireRay = new Ray(transform.position, -transform.up);
        float radius = 0.2f;
        
        if (Physics.SphereCast(tireRay, radius, out RaycastHit tireHit, _springLenght + radius))
        {
            _isGrounded = true;

            _tireModel.transform.position = tireHit.point + transform.up * _tireModelRadius;

            Vector3 springDirection = transform.up;

            Vector3 tireWorldVelocity = _carRb.GetPointVelocity(transform.position);

            //float offset = _springLenght - tireHit.distance;
            float compression = Mathf.Clamp(_springLenght - tireHit.distance, 0, _springLenght);

            float velocity = Vector3.Dot(springDirection, tireWorldVelocity);

            /* (offset > 0f)
            {
                float force = (offset * _springStrength) - (velocity * _springDamping);
                _carRb.AddForceAtPosition(springDirection * force, transform.position);
            }*/

            if (compression > 0f)
            {
                float force = (compression * _springStrength) - (velocity * _springDamping);
                _carRb.AddForceAtPosition(springDirection * force, transform.position);
            }
            
            Debug.DrawRay(transform.position, -transform.up * _springLenght, Color.red);
        }
    }

    private void SideSlip()
    {
        if (!_isGrounded) return;
        
        Vector3 steeringDirection = transform.right;
        
        Vector3 tireWorldVelocity = _carRb.GetPointVelocity(transform.position);
        
        float steeringVel = Vector3.Dot(steeringDirection, tireWorldVelocity);
        
        float carSpeed = Vector3.Dot(transform.forward, _carRb.linearVelocity);
        float sideSlip = _sideSlipCurve.Evaluate(0.5f);                             //TODO Исправить на скорость автомобиля (чем выше - тем больше)
        
        _finalSlipStrength = _sideSlipStrength * _sideSlipDetection * sideSlip;
        float directionVelChange = -steeringVel * _finalSlipStrength;
        
        float desiredAccel =  directionVelChange / Time.fixedDeltaTime;
        
        _carRb.AddForceAtPosition(steeringDirection * _tireMass * desiredAccel, transform.position);
    }

    private void SlipDetection()
    {
        if (!_isDriveTire)
        {
            _sideSlipDetection = 1;
            return;
        }
        
        float carSpeed = _carRb.linearVelocity.magnitude;
        float wheelAngilarVelosity = _car.CalculateTorque() / 5000;
        
        if (wheelAngilarVelosity < 0.01f)
            wheelAngilarVelosity = 0.01f;
        
        float slipRatio = Mathf.Clamp01(wheelAngilarVelosity / carSpeed);
        
        if (slipRatio > 0.3f)
        {
            _isDrifting = true;
            _sideSlipDetection = _sideSlipStrength * (1f - slipRatio);
        }
        else
        {
            _isDrifting = false;
            _sideSlipDetection = 1f;
        }
    }

    public void Acceleration(float torque)
    {
        if (!_isGrounded) return;
        
        Vector3 accelerationDirection = transform.forward;

        float carSpeed = Vector3.Dot(transform.forward, _carRb.linearVelocity);
        
        _carRb.AddForceAtPosition(accelerationDirection * torque, transform.position);
        
        float rotationsPerSecond = carSpeed * Mathf.PI;
        float rotation = _tireModel.transform.localRotation.x;
        rotation += Mathf.Rad2Deg * rotationsPerSecond * Time.fixedDeltaTime * 7.5f;
            
        _tireModel.transform.localRotation = Quaternion.Euler(rotation, _tireYStartRotation, _tireZStartRotation);
    }

    private void RollingResistance()
    {
        if (!_isGrounded) return;

        Vector3 velocity = _carRb.GetPointVelocity(transform.position);
    
        Vector3 resistanceForce = -velocity.normalized;

        _carRb.AddForceAtPosition(resistanceForce, transform.position);
    }

    public void SurfaceDetection()
    {
        Ray ray = new Ray(transform.position, -transform.up);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            switch (hit.transform.tag)
            {
                case "Asphalt":
                    _sideSlipStrength = 1 * _surfaceFriction["Asphalt"];
                    break;
                case "Gravel":
                    _sideSlipStrength = 1 * _surfaceFriction["Gravel"];
                    break;
                case "Dirt":
                    _sideSlipStrength = 1 * _surfaceFriction["Dirt"];
                    break;
                case "Snow":
                    _sideSlipStrength = 1 * _surfaceFriction["Snow"];
                    break;
                case "Ice":
                    _sideSlipStrength = 1 * _surfaceFriction["Ice"];
                    break;
                default:
                    _sideSlipStrength = 1 * _surfaceFriction["Other"];
                    break;
            }
        }
    }
    
    public void SetCarRb(Rigidbody newRb) => _carRb = newRb;
    
    public void SetDriveTire(bool value) => _isDriveTire = value;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position - transform.up * _springLenght);
        
        Vector3 origin = transform.position;
        Vector3 direction = -transform.up;
        float radius = 0.2f;

        Gizmos.DrawWireSphere(origin + direction * _springLenght, radius);
        Gizmos.DrawLine(origin, origin + direction * _springLenght);
    }
}
