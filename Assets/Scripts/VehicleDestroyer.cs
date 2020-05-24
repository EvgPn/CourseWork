using UnityEngine;

public class VehicleDestroyer : MonoBehaviour
{
	//vehicles destroy after end of route
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Vehicle")
		{
			Destroy(other.gameObject);
		}
	}
}
