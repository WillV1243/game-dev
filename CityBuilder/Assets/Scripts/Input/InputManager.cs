using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {
	[Header("References")]
	public Camera playerCamera;

	[Header("Interact Layers")]
	public LayerMask layers;

	[Header("Actions")]
	public Action<Vector3> OnMouseLeftClick, OnMouseLeftHold, OnMouseLeftUp;
	public Action<Vector3> OnMouseRightClick, OnMouseRightHold, OnMouseRightUp;
	public Action<Vector3> OnMouseHover;
	public Action OnMoveForward, OnMoveRight, OnMoveBack, OnMoveLeft;
	public Action OnRotateRight, OnRotateLeft;
	public Action OnZoomIn, OnZoomOut;

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

			if (position != null) OnMouseLeftClick?.Invoke(position.Value);
		}
	}
	private void CheckLeftClickHoldEvent() {
		if (Input.GetMouseButton(0)) {
			Vector3? position = RaycastToGrid();

			if (position != null) OnMouseLeftHold?.Invoke(position.Value);
		}
	}
	private void CheckLeftClickUpEvent() {
		if (Input.GetMouseButtonUp(0)) {
			Vector3? position = RaycastToGrid();

			if (position != null) OnMouseLeftUp?.Invoke(position.Value);
		}
	}

	private void CheckRightClickDownEvent() {
		if (Input.GetMouseButtonDown(1)) {
			Vector3? position = RaycastToGrid();

			if (position != null) OnMouseRightClick?.Invoke(position.Value);
		}
	}
	private void CheckRightClickHoldEvent() {
		if (Input.GetMouseButton(1)) {
			Vector3? position = RaycastToGrid();

			if (position != null) OnMouseRightHold?.Invoke(position.Value);
		}
	}
	private void CheckRightClickUpEvent() {
		if (Input.GetMouseButtonUp(1)) {
			Vector3? position = RaycastToGrid();

			if (position != null) OnMouseRightUp?.Invoke(position.Value);
		}
	}

	private void CheckMouseHover() {
		Vector3? position = RaycastToGrid();

		if (position != null) OnMouseHover?.Invoke(position.Value);
	}

	private void CheckMoveForward() {
		if (Input.GetKey(KeyCode.W)) {
			OnMoveForward.Invoke();
		}
	}
	private void CheckMoveRight() {
		if (Input.GetKey(KeyCode.D)) {
			OnMoveRight.Invoke();
		}
	}
	private void CheckMoveBack() {
		if (Input.GetKey(KeyCode.S)) {
			OnMoveBack.Invoke();
		}
	}
	private void CheckMoveLeft() {
		if (Input.GetKey(KeyCode.A)) {
			OnMoveLeft.Invoke();
		}
	}

	private void CheckRotateRight() {
		if (Input.GetKey(KeyCode.E)) {
			OnRotateRight.Invoke();
		}
	}
	private void CheckRotateLeft() {
		if (Input.GetKey(KeyCode.Q)) {
			OnRotateLeft.Invoke();
		}
	}

	private void CheckZoomIn() {
		if (Input.GetKey(KeyCode.E)) {
			OnRotateRight.Invoke();
		}
	}
	private void CheckZoomOut() {
		if (Input.GetKey(KeyCode.Q)) {
			OnRotateLeft.Invoke();
		}
	}

	private Vector3? RaycastToGrid() {
		Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
		int layerMask = layers;

		if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask)) {
			Debug.DrawLine(ray.origin, hit.point, Color.magenta, 2);

			return hit.point;
		}

		return null;
	}
}
