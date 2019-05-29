using UnityEngine;

public class FlyCamera : MonoBehaviour {

	[SerializeField] private float speed = 5;
	[SerializeField] private float sprintSpeed = 15;
	[SerializeField] private float speedRampUp = 10f;
	[SerializeField] private float mouseSensitivity = 120f;

	[SerializeField] private string sprintKey = "shift";

	private Vector3 currentVelocity;

	void Update() {
		Vector3 vel = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		if (vel.magnitude > 1f) {
			vel.Normalize();
		}
		vel *= (Input.GetKey(sprintKey) ? sprintSpeed : speed) * Time.deltaTime;
		transform.position += transform.TransformDirection(vel);

		Vector3 ang = transform.eulerAngles;
		ang.y += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		ang.x -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
		transform.eulerAngles = ang;
	}
}
