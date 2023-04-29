using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

	[Header("Grid Settings")]
	public float tileSize = 1f;
	public Vector2Int gridSize = new(100, 100);
	public Vector2Int gridOffset = Vector2Int.zero;

	[Header("References")]
	public GameObject tilePrefab;
	public Transform gridContainer;

	private void Start() {
		InitializeGrid();
		CreateGrid();
	}

	private void InitializeGrid() {
		VertexStore.getInstance.CreateStore(gridOffset, gridSize);
		EdgeStore.getInstance.CreateStore(gridOffset, gridSize);
		TileStore.getInstance.CreateStore(gridOffset, gridSize);
	}

	private void CreateGrid() {
		foreach (KeyValuePair<Vector2Int[], Tile> pair in TileStore.getInstance.GetTiles()) {
			GameObject tileObject = Instantiate(tilePrefab);

			Tile tile = pair.Value;

			Vector3 tilePosition = new(tile.vertexD.x + (tileSize / 2), 0, tile.vertexD.y + (tileSize / 2));

			tileObject.name = "GridTile";
			tileObject.transform.SetParent(gridContainer);
			tileObject.transform.position = tilePosition;

			tileObject.GetComponent<BuildGridTile>().tileData = tile;
			tileObject.GetComponent<BuildGridTile>().tileSize = tileSize;
			tileObject.GetComponent<BuildGridTile>().CheckIfAboveTerrain();
		}
	}

}
