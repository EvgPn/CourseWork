using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class VehicleSpawner : MonoBehaviour
{
	//List of Vehicles GameObjects with instances of child classes of Vehicle 
	[SerializeField] private List<GameObject> _vehiclePrefabs = new List<GameObject>();	
	[SerializeField] private List<PathCreator> _paths = new List<PathCreator>();	

	private GameObject _spawnedVehicle;
	private PathFollower _follower;	

	public void Spawn()
	{
		InstantiateRandomVehicle();
	}

	//spawn of random vehicle from List
	private void InstantiateRandomVehicle()
	{
		_spawnedVehicle = Instantiate(_vehiclePrefabs[Random.Range(0, _vehiclePrefabs.Count - 1)], Vector3.down * 3, Quaternion.identity);
		_follower = _spawnedVehicle.AddComponent<PathFollower>();
		_follower._pathCreator = _paths[Random.Range(0, _paths.Count - 1)];
	}
}
