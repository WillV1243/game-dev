using UnityEngine;

namespace Player {

	public class CameraMovement : PlayerSystemBase {

		[Header("Settings")]
		public float cameraMovementSpeed = 5f;
		public float cameraRotateSpeed = 5f;
		public float zoomSpeed = 5f;

		private void Start() {
			player.events.OnMoveForward += HandleMoveForward;
			player.events.OnMoveRight += HandleMoveRight;
			player.events.OnMoveBack += HandleMoveBack;
			player.events.OnMoveLeft += HandleMoveLeft;

			player.events.OnRotateRight += HandleRotateRight;
			player.events.OnRotateLeft += HandleRotateLeft;
		}

		private void HandleMoveForward() {
			MoveCamera(transform.forward);
		}
		private void HandleMoveRight() {
			MoveCamera(transform.right);
		}
		private void HandleMoveBack() {
			MoveCamera(-transform.forward);
		}
		private void HandleMoveLeft() {
			MoveCamera(-transform.right);
		}

		private void HandleRotateLeft() {
			RotateCamera(RotationDirection.Left);
		}
		private void HandleRotateRight() {
			RotateCamera(RotationDirection.Right);
		}

		private void MoveCamera(Vector3 inputVector) {
			transform.position += inputVector * Time.deltaTime * cameraMovementSpeed;
		}

		private void RotateCamera(RotationDirection rotationDirection) {
			switch (rotationDirection) {
				case RotationDirection.Left:
					transform.Rotate(0, cameraRotateSpeed * Time.deltaTime, 0);
					break;

				case RotationDirection.Right:
					transform.Rotate(0, -cameraRotateSpeed * Time.deltaTime, 0);
					break;
			}
		}

		private void ZoomCamera() {

		}

	}

}
