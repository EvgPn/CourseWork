using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{	
	[SerializeField] private float _intervalBetweenSpawn;
	public static float _minSpeedInterval;
	public static float _maxSpeedInterval;

	private void OnEnable()
    {
        InputController.SetSpeedInterval += SetSpeedIntervalsFromInput;
    }

	private void Start()
	{
		StartCoroutine(DoCheck());
	}

	private void SetSpeedIntervalsFromInput(float min, float max)
	{
		_minSpeedInterval = min;
		_maxSpeedInterval = max;
	}

	private void SetTimeSpawnInterval(float seconds)
	{
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
