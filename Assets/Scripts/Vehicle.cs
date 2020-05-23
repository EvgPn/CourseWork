using System.Collections;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
	//frorward ray parametrs
	private Vector3 _directionOfRay = new Vector3(0, 0, 1);
	private Color _colorOfRay = Color.red;
	public float LengthOfRay { get; set; }

	//parametrs for speed selection
	public float MinMoveSpeed { get; set; }
	public float MaxMoveSpeed { get; set; }

	protected float _randomSelectedSpeed;
	protected float _minSpeedInterval = SpawnController._minSpeedInterval;
	protected float _maxSpeedInterval = SpawnController._maxSpeedInterval;

	//parametrs for roundabout check ray
	public bool CheckRoundaboutCars = false;

	private void Start()
	{
		SetMoveSpeed();
		SetLengthOfRay(1f);
	}

	private void Update()
	{
		DrawVisibleInEditorRay(transform.position + Vector3.up / 2, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * _directionOfRay * LengthOfRay, _colorOfRay);
		CastRayForwardFromVehicle();
		if (CheckRoundaboutCars) CastRayOnRoundabout();
	}

	protected virtual void SetMoveSpeed()
	{
		ChangeSpeedLimits(_minSpeedInterval, _maxSpeedInterval);
		ChooseNewRandomSpeed();
	}

	protected void ChangeSpeedLimits(float minSpeed, float maxSpeed)
	{
		MinMoveSpeed = minSpeed;
		MaxMoveSpeed = maxSpeed;
	}

	protected void ChooseNewRandomSpeed()
	{
		_randomSelectedSpeed = Random.Range(MinMoveSpeed, MaxMoveSpeed);
		gameObject.GetComponent<PathFollower>()._moveSpeed = _randomSelectedSpeed;
	}

	protected virtual void SetLengthOfRay(float length)
	{
		LengthOfRay = length;
	}

	protected void DrawVisibleInEditorRay(Vector3 rayStart, Vector3 rayDirection, Color rayColor)
	{
		Debug.DrawRay(rayStart, rayDirection, rayColor);
	}

	protected void CastRayForwardFromVehicle()
	{
		RaycastHit hit;
		if (Physics.SphereCast(transform.position + Vector3.up / 2, 0.2f, Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * _directionOfRay, out hit, LengthOfRay))
		{
			if (hit.distance < (LengthOfRay - 1f) && hit.transform.gameObject.tag == "Vehicle")
			{
				gameObject.GetComponent<PathFollower>()._moveSpeed = 0f;
			}
			else if (hit.transform.gameObject.tag == "Vehicle")
			{
				gameObject.GetComponent<PathFollower>()._moveSpeed = hit.transform.gameObject.GetComponent<PathFollower>()._moveSpeed;
			}
			else
			{
				gameObject.GetComponent<PathFollower>()._moveSpeed = _randomSelectedSpeed;
			}
		}
		else
		{
			gameObject.GetComponent<PathFollower>()._moveSpeed = _randomSelectedSpeed;
		}
	}


	protected void CastRayOnRoundabout()
	{
		DrawVisibleInEditorRay(transform.position + Vector3.up / 2, Quaternion.Euler(0, transform.rotation.eulerAngles.y - 55f, 0) * _directionOfRay * (LengthOfRay + 1.5f), _colorOfRay);

		RaycastHit hit;
		if (Physics.SphereCast(transform.position + Vector3.up / 2, 1f, Quaternion.Euler(0, transform.rotation.eulerAngles.y - 55f, 0) * _directionOfRay, out hit, LengthOfRay + 1.5f))
		{
			CheckRoundaboutCars = true;
			if (hit.transform.gameObject.tag == "Vehicle")
			{
				gameObject.GetComponent<PathFollower>()._moveSpeed = 0f;
				StartCoroutine(WaitOnRoundaboutCheck());
			}
		}
		else
		{
			CheckRoundaboutCars = false;
		}
	}

	protected IEnumerator WaitOnRoundaboutCheck()
	{
		yield return new WaitForSeconds(2f);
	}
}
