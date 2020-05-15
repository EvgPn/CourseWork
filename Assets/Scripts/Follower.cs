using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class Follower : MonoBehaviour
{
	public PathCreator pathCreator;
	public float moveSpeed = 30f;
	private float distanceTravelled;

	private void Update()
	{
		distanceTravelled += moveSpeed * Time.deltaTime;
		transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled);
		transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled);
	}
}
