using UnityEngine;

public class CameraMovement : MonoBehaviour {

	[Header("References")]
	public Camera playerCamera;

	[Header("Settings")]
	public float cameraMovementSpeed = 5f;
	public float cameraRotateSpeed = 5f;
	public float zoomSpeed = 5f;

	public void MoveCamera(Vector3 inputVector) {
		Vector3 movementVector = Quaternion.Euler(0, 45, 0) * inputVector;

		transform.position += movementVector * Time.deltaTime * cameraMovementSpeed;
	}

	public void RotateCamera(RotationDirection rotationDirection) {
		switch (rotationDirection) {
			case RotationDirection.Left:
				transform.Rotate(0, cameraRotateSpeed * Time.deltaTime, 0);
				break;

			case RotationDirection.Right:
				transform.Rotate(0, -cameraRotateSpeed * Time.deltaTime, 0);
				break;
		}
	}

	public void ZoomCamera() {

	}

}
