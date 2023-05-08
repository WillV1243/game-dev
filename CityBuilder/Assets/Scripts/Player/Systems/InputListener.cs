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

				CheckMiddleClickDownEvent();
				CheckMiddleClickHoldEvent();
				CheckMiddleClickUpEvent();

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
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseLeftClick?.Invoke(cursorTarget);
			}
		}
		private void CheckLeftClickHoldEvent() {
			if (Input.GetMouseButton(0)) {
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseLeftHold?.Invoke(cursorTarget);
			}
		}
		private void CheckLeftClickUpEvent() {
			if (Input.GetMouseButtonUp(0)) {
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseLeftUp?.Invoke(cursorTarget);
			}
		}

		private void CheckRightClickDownEvent() {
			if (Input.GetMouseButtonDown(1)) {
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseRightClick?.Invoke(cursorTarget);
			}
		}
		private void CheckRightClickHoldEvent() {
			if (Input.GetMouseButton(1)) {
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseRightHold?.Invoke(cursorTarget);
			}
		}
		private void CheckRightClickUpEvent() {
			if (Input.GetMouseButtonUp(1)) {
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseRightUp?.Invoke(cursorTarget);
			}
		}

		private void CheckMiddleClickDownEvent() {
			if (Input.GetMouseButtonDown(2)) {
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseMiddleClick?.Invoke(cursorTarget);
			}
		}
		private void CheckMiddleClickHoldEvent() {
			if (Input.GetMouseButton(2)) {
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseMiddleHold?.Invoke(cursorTarget);
			}
		}
		private void CheckMiddleClickUpEvent() {
			if (Input.GetMouseButtonUp(2)) {
				CursorTarget cursorTarget = RaycastToWorld();

				if (cursorTarget != null) player.events.OnMouseMiddleUp?.Invoke(cursorTarget);
			}
		}

		private void CheckMouseHover() {
			CursorTarget cursorTarget = RaycastToWorld();

			if (cursorTarget != null) player.events.OnMouseHover?.Invoke(cursorTarget);
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

		private CursorTarget RaycastToWorld() {
			Ray ray = player.references.mainCamera.ScreenPointToRay(Input.mousePosition);
			int layerMask = layers;

			if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask)) {
				Debug.DrawLine(ray.origin, hit.point, Color.magenta, 2);

				return new CursorTarget(hit);
			}

			return null;
		}

	}

}


