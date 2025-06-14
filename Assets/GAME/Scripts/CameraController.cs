
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject[] _cameras;
    [SerializeField] private int _currentIndex = 0;

    private void OnEnable()
    {
        EventBus.SwitchCamera += SwitchCamera;
        
        
    }

    private void OnDisable()
    {
        EventBus.SwitchCamera -= SwitchCamera;

        
        
    }

    public void SwitchCamera()
    {
        _currentIndex++;
            
        if (_currentIndex > _cameras.Length - 1)
            _currentIndex = 0;
        
        for (int i = 0; i < _cameras.Length; i++)
        {
            _cameras[i].SetActive(i == _currentIndex);
        }
    }
}
