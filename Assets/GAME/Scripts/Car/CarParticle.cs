using System;
using UnityEngine;

public class CarParticle : MonoBehaviour
{
    [SerializeField] private Car _car;
    
    //FL FR RL RR (0, 1, 2 ,3)
    [SerializeField] private ParticleSystem[] _asphaltAndSnowParticles;
    [SerializeField] private ParticleSystem[] _gravelParticles;
    [SerializeField] private ParticleSystem[] _dirtParticles;

    private void FixedUpdate()
    {
       // CheckWheel();
    }

    public void CheckWheel()
    {
        for (int i = 0; i < _car.DrivingWheels.Length; i++)
        {
            
        }
    }
}
