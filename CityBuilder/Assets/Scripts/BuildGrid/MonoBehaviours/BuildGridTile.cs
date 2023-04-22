using UnityEngine;

public class BuildGridTile : MonoBehaviour {

	[Header("References")]
	public GameObject tileObject;

	[Header("Layers")]
	public LayerMask terrainLayer;

	[Header("Materials")]
	public Material tileMaterial;
	public Material disabledTileMaterial;

	[Header("Settings")]
	public float detectionDistance;

	public Tile tileData;
	public float tileSize;

	public void CheckIfAboveTerrain() {
		bool isAboveTerrain = true;

		foreach (Vertex vertex in tileData.GetVertices()) {
			Ray ray = new(new Vector3(vertex.x * tileSize, transform.position.y, vertex.y * tileSize), Vector3.down);

			if (Physics.Raycast(ray, out RaycastHit hit, detectionDistance, terrainLayer)) {

				Debug.DrawLine(new Vector3(vertex.x * tileSize, transform.position.y, vertex.y * tileSize), hit.point, Color.yellow, 10);

			} else {

				isAboveTerrain = false;

			}
		}

		if (isAboveTerrain) HandleEnableTile();
	}

	private void HandleEnableTile() {
		tileData.Enable();
		tileObject.GetComponent<Renderer>().material = tileMaterial;
	}
}
