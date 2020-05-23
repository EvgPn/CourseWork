using UnityEngine;

public class VehicleDestroyer : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Vehicle")
		{
			Destroy(other.gameObject);
		}
	}
}
