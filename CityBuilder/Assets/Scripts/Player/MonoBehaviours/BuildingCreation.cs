using System.Collections.Generic;
using UnityEngine;

public class BuildingCreation : MonoBehaviour {

	[Header("References")]
	public GameObject buildingContainer;

	[Header("Prefabs")]
	public GameObject buildingPrefab;
	public GameObject buildingHighlightPrefab;

	private GameObject currentBuildingHighlight;

	public void CreateBuilding(Vector2 gridPosition) {
		TileStore tileStore = TileStore.getInstance;

		Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(gridPosition);
		Tile rootTile = tileStore.GetTile(tileCoordinates);

		Dictionary<Vector2Int[], Tile> tiles = tileStore.GetTileNeighbours(rootTile, new Vector2Int(2, 2));

		Destroy(currentBuildingHighlight);

		GameObject building = Instantiate(buildingPrefab);

		Vector2Int rootTileCoordinates = rootTile.vertexD.GetCoordinates();
		Vector3 buildingPosition = new(rootTileCoordinates.x, 0, rootTileCoordinates.y);

		building.transform.parent = buildingContainer.transform;
		building.transform.position = buildingPosition;
	}

	public void CreateBuildingHighlight(Vector2 gridPosition) {
		TileStore tileStore = TileStore.getInstance;

		Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(gridPosition);
		Tile rootTile = tileStore.GetTile(tileCoordinates);

		Vector2Int rootTileCoordinates = rootTile.vertexD.GetCoordinates();
		Vector3 buildingPosition = new(rootTileCoordinates.x, 0, rootTileCoordinates.y);

		Debug.Log(currentBuildingHighlight);

		if (currentBuildingHighlight == null) {

			Dictionary<Vector2Int[], Tile> tiles = tileStore.GetTileNeighbours(rootTile, new Vector2Int(2, 2));

			currentBuildingHighlight = Instantiate(buildingHighlightPrefab);
			currentBuildingHighlight.transform.parent = buildingContainer.transform;
			currentBuildingHighlight.transform.position = buildingPosition;

		} else {

			if (currentBuildingHighlight.transform.position != buildingPosition) {

				currentBuildingHighlight.transform.position = buildingPosition;

			}

		}

	}
}
