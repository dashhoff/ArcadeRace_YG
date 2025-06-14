using System;
using UnityEngine;

public class EventBus : MonoBehaviour
{
    
    public static event Action SwitchCamera;

    public static void InvokeSwitchCamera() => SwitchCamera?.Invoke();
}
