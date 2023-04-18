using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour {
	[Header("References")]
	public Camera playerCamera;
	public LayerMask gridLayer;
	public LayerMask buildingLayer;

	[Header("Actions")]
	public Action<Vector3> OnMouseClick, OnMouseHold, OnMouseUp;

	private void Update() {
		if (EventSystem.current.IsPointerOverGameObject() == false) {
			CheckClickDownEvent();
			CheckClickHoldEvent();
			CheckClickUpEvent();
		}
	}

	private void CheckClickDownEvent() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3? position = RaycastToGrid();

			if (position != null) {
				OnMouseClick?.Invoke(position.Value);
			}
		}
	}

	private void CheckClickHoldEvent() {
		if (Input.GetMouseButton(0)) {
			Vector3? position = RaycastToGrid();

			if (position != null) {
				OnMouseHold?.Invoke(position.Value);
			}
		}
	}

	private void CheckClickUpEvent() {
		if (Input.GetMouseButtonUp(0)) {
			Vector3? position = RaycastToGrid();

			if (position != null) {
				OnMouseUp?.Invoke(position.Value);
			}
		}
	}

	private Vector3? RaycastToGrid() {
		Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
		int layerMask = gridLayer | buildingLayer;

		if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask)) {

			Debug.DrawLine(ray.origin, hit.point, Color.magenta, 2);

			return hit.point;
		}

		return null;
	}
}
