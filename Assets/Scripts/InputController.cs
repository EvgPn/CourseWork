using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public delegate void InputSpeedParamsCallBack(float minSpeed, float maxSpeed);
    public static event InputSpeedParamsCallBack SetSpeedInterval;

    public delegate void InputSpawnIntervalCallBack(float seconds);
    public static event InputSpawnIntervalCallBack SetSpawnTimeInterval;
    
    private void Start()
    {
        SetSpeedInterval?.Invoke(3, 10);
        SetSpawnTimeInterval?.Invoke(7);
    }
}
