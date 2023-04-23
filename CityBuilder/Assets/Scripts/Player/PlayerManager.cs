using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	[Header("References")]
	public InputManager inputManager;
	public CameraMovement cameraMovement;

	public Action<PlayerState[]> OnChangePlayerState;

	private PlayerStateBase playerState;

	private void Start() {
		playerState = GetComponent<PlayerStateBase>();

		inputManager.OnMouseLeftClick += HandleMouseClick;

		inputManager.OnMoveForward += HandleMoveForward;
		inputManager.OnMoveRight += HandleMoveRight;
		inputManager.OnMoveBack += HandleMoveBack;
		inputManager.OnMoveLeft += HandleMoveLeft;

		inputManager.OnRotateRight += HandleRotateRight;
		inputManager.OnRotateLeft += HandleRotateLeft;

		OnChangePlayerState += HandlePlayerBuilding;
	}

	public void ChangeState(PlayerState state) {
		if (state == playerState.GetStateType()) return;

		OnChangePlayerState.Invoke(new PlayerState[2] { state, GetComponent<PlayerStateBase>().GetStateType() });

		Destroy(GetComponent<PlayerStateBase>());

		switch (state) {
			case PlayerState.Idle:
				playerState = gameObject.AddComponent<IdleState>();
				break;

			case PlayerState.Building:
				playerState = gameObject.AddComponent<BuildingState>();
				break;

			case PlayerState.Removing:
				playerState = gameObject.AddComponent<RemovingState>();
				break;
		}
	}

	private void HandlePlayerBuilding(PlayerState[] states) {
		PlayerState currState = states[0], prevState = states[1];

		if (currState == PlayerState.Building) {

			inputManager.OnMouseHover += HandleMouseHover;

		} else if (currState != PlayerState.Building) {

			inputManager.OnMouseHover -= HandleMouseHover;

		}
	}

	private void HandleMoveForward() {
		cameraMovement.MoveCamera(transform.forward);
	}
	private void HandleMoveRight() {
		cameraMovement.MoveCamera(transform.right);
	}
	private void HandleMoveBack() {
		cameraMovement.MoveCamera(-transform.forward);
	}
	private void HandleMoveLeft() {
		cameraMovement.MoveCamera(-transform.right);
	}

	private void HandleRotateLeft() {
		cameraMovement.RotateCamera(RotationDirection.Left);
	}
	private void HandleRotateRight() {
		cameraMovement.RotateCamera(RotationDirection.Right);
	}

	private void HandleMouseClick(Vector3 position) {
		Vector2 gridPosition = new(position.x, position.z);

		playerState.HandleMouseClick(gridPosition, (bool success) => {
			if (success) ChangeState(PlayerState.Idle);
		});
	}

	private void HandleMouseHover(Vector3 position) {
		Vector2 gridPosition = new(position.x, position.z);

		playerState.HandleMouseHover(gridPosition);
	}

}
