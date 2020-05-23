using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] private GameObject _cameraGO = null;
	private float _mouseSensitivity = 100f;
	private float _xRotation = 0f;

	private float _speedOfCamera = 12f;


	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Update()
	{
		float xMouseInput = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSensitivity;
		_cameraGO.transform.Rotate(Vector3.up * xMouseInput);

		float yMouseInput = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSensitivity;

		_xRotation -= yMouseInput;
		_xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;

		gameObject.GetComponentInParent<CharacterController>().Move(move * _speedOfCamera * Time.deltaTime);
	}
}
