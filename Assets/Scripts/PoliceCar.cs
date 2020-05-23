public class PoliceCar : Vehicle
{
	protected override void SetMoveSpeed()
	{
		GetSpeedInterval(_minSpeedInterval, _maxSpeedInterval);
		base.ChooseNewRandomSpeed();
	}

	private void GetSpeedInterval(float minSpeed, float maxSpeed)
	{
		if (minSpeed < 1) minSpeed = 1;
		if (maxSpeed > 7) maxSpeed = 7;

		base.ChangeSpeedLimits(minSpeed, maxSpeed);
	}

	protected override void SetLengthOfRay(float length) => base.SetLengthOfRay(6f);
}
