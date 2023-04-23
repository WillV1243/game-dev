using System;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	[Header("References")]
	public InputManager inputManager;
	public CameraMovement cameraMovement;
	public BuildingCreation buildingCreation;

	public Action<PlayerState[]> OnChangePlayerState;

	private PlayerState playerState = PlayerState.Idle;

	private void Start() {
		inputManager.OnMouseLeftClick += HandleMouseClick;

		inputManager.OnMoveForward += HandleMoveForward;
		inputManager.OnMoveRight += HandleMoveRight;
		inputManager.OnMoveBack += HandleMoveBack;
		inputManager.OnMoveLeft += HandleMoveLeft;

		inputManager.OnRotateRight += HandleRotateRight;
		inputManager.OnRotateLeft += HandleRotateLeft;

		OnChangePlayerState += IsPlayerBuilding;
	}

	public void ChangeState(PlayerState state) {
		OnChangePlayerState.Invoke(new PlayerState[2] { state, playerState });

		playerState = state;
	}

	private void IsPlayerBuilding(PlayerState[] states) {
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
		if (playerState == PlayerState.Building) {
			buildingCreation.CreateBuilding(new Vector2(position.x, position.z));

			ChangeState(PlayerState.Idle);
		}
	}

	private void HandleMouseHover(Vector3 position) {
		Vector2 gridPosition = new(position.x, position.z);

		buildingCreation.CreateBuildingHighlight(gridPosition);
	}

}
