using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
	[SerializeField] private float _minVehicleSpeed;
	[SerializeField] private float _maxVehicleSpeed;
	[SerializeField] private float _intervalBetweenSpawn = 4;

	private void Start()
	{
		StartCoroutine(DoCheck());
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
