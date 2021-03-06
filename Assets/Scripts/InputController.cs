﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
	//events for handing of input speed limits and time intervals data
	public delegate void InputSpeedParamsCallBack(float minSpeed, float maxSpeed);
	public static event InputSpeedParamsCallBack SetSpeedInterval;

	public delegate void InputSpawnIntervalCallBack(float seconds);
	public static event InputSpawnIntervalCallBack SetSpawnTimeInterval;

	[SerializeField] private InputField _intervalsForSpawn = null;
	[SerializeField] private InputField _speedInterval = null;
	[SerializeField] private List<GameObject> _spawnPoints = new List<GameObject>();

	private void Start()
	{
		SetSpeedInterval?.Invoke(3, 10);
		SetSpawnTimeInterval?.Invoke(7);
	}

	//seting of spwn vehicle intervals for each spawn point of road
	public void SetSpawnIntervals()
	{
		string[] intervals = _intervalsForSpawn.text.Split(' ');
		int i = 0;
		foreach(GameObject spawnPoint in _spawnPoints)
		{
			spawnPoint.GetComponent<SpawnController>().SetTimeSpawnInterval(float.Parse(intervals[i]));
			i++;
		}
	}

	//seting of vehicle speed interval
	public void SetNewSpeedInterval()
	{
		string[] interval = _speedInterval.text.Split(' ');
		SetSpeedInterval?.Invoke((float.Parse(interval[0]))/10, (float.Parse(interval[1]))/10);
	}
}
