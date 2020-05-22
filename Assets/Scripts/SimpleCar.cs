using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCar : Vehicle
{   
    public override void SetMoveSpeed()
    {
        GetSpeedInterval(_minSpeedInterval, _maxSpeedInterval);
        base.ChooseNewRandomSpeed();
    }
    
    private void GetSpeedInterval(float minSpeed, float maxSpeed)
    {
        if (minSpeed < 1) minSpeed = 1;
        if (maxSpeed > 5) maxSpeed = 5;

        base.ChangeSpeedLimits(minSpeed, maxSpeed);
    }
}
