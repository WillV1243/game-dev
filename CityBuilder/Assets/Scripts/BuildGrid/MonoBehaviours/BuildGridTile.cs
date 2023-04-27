using UnityEngine;

public class BuildGridTile : MonoBehaviour {

	[Header("References")]
	public GameObject tileObject;

	[Header("Layers")]
	public LayerMask terrainLayer;

	[Header("Settings")]
	public float detectionDistance;

	public Tile tileData;
	public float tileSize;

	public void CheckIfAboveTerrain() {
		bool isAboveTerrain = true;

		foreach (Vertex vertex in tileData.GetVertices()) {
			Ray ray = new(new Vector3(vertex.x * tileSize, transform.position.y, vertex.y * tileSize), Vector3.down);

			if (!Physics.Raycast(ray, out RaycastHit hit, detectionDistance, terrainLayer)) isAboveTerrain = false;
		}

		if (isAboveTerrain) HandleEnableTile();
	}

	private void HandleEnableTile() {
		tileData.Enable();
	}
}
