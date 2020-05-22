﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PathFollower : MonoBehaviour
{
	public PathCreator _pathCreator;
	public float _moveSpeed = 0f;

	private EndOfPathInstruction _endOfPathInstruction = EndOfPathInstruction.Stop;
	private float _distanceTravelled;
	
	private void Update()
	{
		_distanceTravelled += _moveSpeed * Time.deltaTime;
		transform.position = _pathCreator.path.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
		transform.rotation = _pathCreator.path.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);		
	}
}