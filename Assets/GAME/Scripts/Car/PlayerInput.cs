using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Car _car;
    
    [SerializeField] private float _accelerationInput;
    [SerializeField] private float _turnInput;
    
    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _accelerationInput = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _accelerationInput = -1;
        }
        else
        {
            _accelerationInput = 0;
        }
        
        _car.SetAcceleration(_accelerationInput);
        
        if (Input.GetKey(KeyCode.D))
        {
            _turnInput= 60;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _turnInput = -60;
        }
        else
        {
            _turnInput = 0;
        }
        
        _car.RotateFrontWheel(_turnInput);
        
        if (Input.GetKeyDown(KeyCode.E))
            _car._gearbox.UpGear();
        if(Input.GetKeyDown(KeyCode.Q))
            _car._gearbox.DownGear();
    }
}
