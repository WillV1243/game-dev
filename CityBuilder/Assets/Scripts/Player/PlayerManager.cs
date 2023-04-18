using UnityEngine;

public class PlayerManager : MonoBehaviour {

	[Header("References")]
	public InputManager inputManager;

	private PlayerState playerState = PlayerState.Idle;

	private void Start() {
		inputManager.OnMouseClick += HandleMouseClick;
	}

	private void HandleMouseClick(Vector3 position) {
		float firstMinDistance = float.MaxValue;
		float secondMinDistance = float.MaxValue;

		Vector2Int closestVertex = Vector2Int.zero;
		Vector2Int secondClosestVertex = closestVertex;

		Vector2Int[] vertexCoordinates = new Vector2Int[4];

		vertexCoordinates[0] = new Vector2Int(Mathf.FloorToInt(position.x), Mathf.CeilToInt(position.z));
		vertexCoordinates[1] = new Vector2Int(Mathf.CeilToInt(position.x), Mathf.CeilToInt(position.z));
		vertexCoordinates[2] = new Vector2Int(Mathf.CeilToInt(position.x), Mathf.FloorToInt(position.z));
		vertexCoordinates[3] = new Vector2Int(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.z));

		foreach (Vector2Int vertex in vertexCoordinates) {
			float distance = Vector2.Distance(position, vertex);

			if (distance < firstMinDistance) {
				secondMinDistance = firstMinDistance;
				firstMinDistance = distance;
				secondClosestVertex = closestVertex;
				closestVertex = vertex;
			}
		}

		// I have no idea whats happening here...
		// something to do with the keys for edges + tiles
	}

	public void ChangeState(PlayerState state) {
		playerState = state;

		Debug.Log("PlayerState changed: " + playerState.ToString());
	}

}
