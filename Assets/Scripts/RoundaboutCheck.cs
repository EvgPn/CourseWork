using UnityEngine;

public class RoundaboutCheck : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Vehicle")
		{
			other.gameObject.GetComponent<Vehicle>().CheckRoundaboutCars = true;
		}
	}
}
