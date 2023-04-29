using UnityEngine;
using UnityEngine.EventSystems;

namespace Player {

	public class InputListener : PlayerSystemBase {

		[Header("Interact Layers")]
		public LayerMask layers;

		private void Update() {
			if (EventSystem.current.IsPointerOverGameObject() == false) {
				CheckLeftClickDownEvent();
				CheckLeftClickHoldEvent();
				CheckLeftClickUpEvent();
				CheckRightClickDownEvent();
				CheckRightClickHoldEvent();
				CheckRightClickUpEvent();

				CheckMouseHover();
			}

			CheckMoveForward();
			CheckMoveRight();
			CheckMoveBack();
			CheckMoveLeft();

			CheckRotateRight();
			CheckRotateLeft();

			CheckZoomIn();
			CheckZoomOut();
		}

		private void CheckLeftClickDownEvent() {
			if (Input.GetMouseButtonDown(0)) {
				Vector3? position = RaycastToGrid();

				if (position != null) player.events.OnMouseLeftClick?.Invoke(position.Value);
			}
		}
		private void CheckLeftClickHoldEvent() {
			if (Input.GetMouseButton(0)) {
				Vector3? position = RaycastToGrid();

				if (position != null) player.events.OnMouseLeftHold?.Invoke(position.Value);
			}
		}
		private void CheckLeftClickUpEvent() {
			if (Input.GetMouseButtonUp(0)) {
				Vector3? position = RaycastToGrid();

				if (position != null) player.events.OnMouseLeftUp?.Invoke(position.Value);
			}
		}

		private void CheckRightClickDownEvent() {
			if (Input.GetMouseButtonDown(1)) {
				Vector3? position = RaycastToGrid();

				if (position != null) player.events.OnMouseRightClick?.Invoke(position.Value);
			}
		}
		private void CheckRightClickHoldEvent() {
			if (Input.GetMouseButton(1)) {
				Vector3? position = RaycastToGrid();

				if (position != null) player.events.OnMouseRightHold?.Invoke(position.Value);
			}
		}
		private void CheckRightClickUpEvent() {
			if (Input.GetMouseButtonUp(1)) {
				Vector3? position = RaycastToGrid();

				if (position != null) player.events.OnMouseRightUp?.Invoke(position.Value);
			}
		}

		private void CheckMouseHover() {
			Vector3? position = RaycastToGrid();

			if (position != null) player.events.OnMouseHover?.Invoke(position.Value);
		}

		private void CheckMoveForward() {
			if (Input.GetKey(KeyCode.W)) {
				player.events.OnMoveForward?.Invoke();
			}
		}
		private void CheckMoveRight() {
			if (Input.GetKey(KeyCode.D)) {
				player.events.OnMoveRight?.Invoke();
			}
		}
		private void CheckMoveBack() {
			if (Input.GetKey(KeyCode.S)) {
				player.events.OnMoveBack?.Invoke();
			}
		}
		private void CheckMoveLeft() {
			if (Input.GetKey(KeyCode.A)) {
				player.events.OnMoveLeft?.Invoke();
			}
		}

		private void CheckRotateRight() {
			if (Input.GetKey(KeyCode.E)) {
				player.events.OnRotateRight?.Invoke();
			}
		}
		private void CheckRotateLeft() {
			if (Input.GetKey(KeyCode.Q)) {
				player.events.OnRotateLeft?.Invoke();
			}
		}

		private void CheckZoomIn() {
			if (Input.GetKey(KeyCode.E)) {
				player.events.OnRotateRight?.Invoke();
			}
		}
		private void CheckZoomOut() {
			if (Input.GetKey(KeyCode.Q)) {
				player.events.OnRotateLeft?.Invoke();
			}
		}

		private Vector3? RaycastToGrid() {
			Ray ray = player.references.mainCamera.ScreenPointToRay(Input.mousePosition);
			int layerMask = layers;

			if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask)) {
				Debug.DrawLine(ray.origin, hit.point, Color.magenta, 2);

				return hit.point;
			}

			return null;
		}

	}

}

