using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bus : Vehicle
{
    protected override void SetMoveSpeed()
    {
        GetSpeedInterval(_minSpeedInterval, _maxSpeedInterval);
        base.ChooseNewRandomSpeed();
    }

    private void GetSpeedInterval(float minSpeed, float maxSpeed)
    {
        if (minSpeed < 1) minSpeed = 1;
        if (maxSpeed > 4) maxSpeed = 4;

        base.ChangeSpeedLimits(minSpeed, maxSpeed);
    }

    protected override void SetLengthOfRay(float length) => base.SetLengthOfRay(7f);
}
