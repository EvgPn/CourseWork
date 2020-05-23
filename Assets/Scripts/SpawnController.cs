using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
	private float _intervalBetweenSpawn;
	public static float _minSpeedInterval;
	public static float _maxSpeedInterval;

	private void OnEnable()
	{
		InputController.SetSpeedInterval += SetSpeedIntervalsFromInput;
		InputController.SetSpawnTimeInterval += SetTimeSpawnInterval;
	}

	private void Start()
	{
		StartCoroutine(DoCheck());
	}

	private void SetSpeedIntervalsFromInput(float min, float max)
	{
		if (min < 3) min = 3;
		if (max > 10) max = 10;
		_minSpeedInterval = min;
		_maxSpeedInterval = max;
	}

	public void SetTimeSpawnInterval(float seconds)
	{
		if (seconds < 5) seconds = 5;
		_intervalBetweenSpawn = seconds;
	}

	private IEnumerator DoCheck()
	{
		while (true)
		{
			gameObject.GetComponent<VehicleSpawner>().Spawn();
			yield return new WaitForSeconds(_intervalBetweenSpawn);
		}
	}
}
