using UnityEngine;

public class RoundaboutCheck : MonoBehaviour
{
	//checking of vehicles before racing on roundabout
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Vehicle")
		{
			other.gameObject.GetComponent<Vehicle>().CheckRoundaboutCars = true;
		}
	}
}
