using UnityEngine;

public class PlayerManager : MonoBehaviour {

	[Header("References")]
	public InputManager inputManager;
	public CameraMovement cameraMovement;

	private PlayerState playerState = PlayerState.Idle;

	private void Start() {
		inputManager.OnMouseLeftClick += HandleMouseClick;

		inputManager.OnMoveForward += HandleMoveForward;
		inputManager.OnMoveRight += HandleMoveRight;
		inputManager.OnMoveBack += HandleMoveBack;
		inputManager.OnMoveLeft += HandleMoveLeft;

		inputManager.OnRotateRight += HandleRotateRight;
		inputManager.OnRotateLeft += HandleRotateLeft;
	}

	public void ChangeState(PlayerState state) {
		playerState = state;
	}

	private void HandleMoveForward() {
		cameraMovement.MoveCamera(Vector3.forward);
	}
	private void HandleMoveRight() {
		cameraMovement.MoveCamera(Vector3.right);
	}
	private void HandleMoveBack() {
		cameraMovement.MoveCamera(Vector3.back);
	}
	private void HandleMoveLeft() {
		cameraMovement.MoveCamera(Vector3.left);
	}

	private void HandleRotateLeft() {
		cameraMovement.RotateCamera(RotationDirection.Left);
	}
	private void HandleRotateRight() {
		cameraMovement.RotateCamera(RotationDirection.Right);
	}

	private void HandleMouseClick(Vector3 position) {
		Vector2 flattenedPosition = new(position.x, position.z);

		switch (playerState) {
			case PlayerState.Idle:
				break;

			case PlayerState.TileBuilding:
				HandleBuildTile(flattenedPosition);
				break;

			case PlayerState.PathBuilding:
				HandleBuildPath(flattenedPosition);
				break;

			case PlayerState.NodeBuilding:
				HandleBuildNode(flattenedPosition);
				break;
		}
	}

	private void HandleBuildTile(Vector2 flattenedPosition) {
		Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(flattenedPosition);

		Tile tile = TileStore.getInstance.GetTile(tileCoordinates);

		Debug.Log(tile);
	}

	private void HandleBuildPath(Vector2 flattenedPosition) {
		Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(flattenedPosition);
		Vector2Int[] edgeCoordinates = PlayerUtils.GetEdgeCoordinates(tileCoordinates, flattenedPosition);

		Edge edge = EdgeStore.getInstance.GetEdge(edgeCoordinates);

		Debug.Log(edge);
	}

	private void HandleBuildNode(Vector2 flattenPosition) {
		Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(flattenPosition);
		Vector2Int vertexCoordinates = PlayerUtils.GetVertexCoordinates(tileCoordinates, flattenPosition);

		Vertex vertex = VertexStore.getInstance.GetVertex(vertexCoordinates);

		Debug.Log(vertex);
	}

}
