using System.Collections.Generic;
using UnityEngine;

public class BuildingCreation : MonoBehaviour {

	[Header("References")]
	public GameObject buildingContainer;

	[Header("Prefabs")]
	public GameObject buildingPrefab;
	public GameObject buildingHighlightPrefab;

	private GameObject currentBuildingHighlight;

	public void CreateBuilding(Vector2 gridPosition, out bool success) {
		Vector3 buildingPosition = GetBuildingPosition(gridPosition, out Tile rootTile);

		Dictionary<Vector2Int[], Tile> tiles = TileStore.getInstance.GetTileNeighbours(rootTile, new Vector2Int(2, 2));

		foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
			if (!pair.Value.IsTileBuildable()) {
				Debug.Log("Not buildable!!!");
				success = false;
				return;
			};
		}

		InstantiateBuilding(buildingPosition);

		foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
			pair.Value.ChangeState(TileState.Occupied);
		}

		success = true;
	}

	public void CreateBuildingHighlight(Vector2 gridPosition) {
		Vector3 buildingPosition = GetBuildingPosition(gridPosition, out Tile rootTile);

		if (currentBuildingHighlight == null) {

			InstantiateBuildingHighlight(gridPosition);

		} else if (currentBuildingHighlight.transform.position != buildingPosition) {

			MoveBuildingHighlight(buildingPosition, rootTile);

		}
	}

	private void InstantiateBuilding(Vector3 buildingPosition) {
		Destroy(currentBuildingHighlight);

		GameObject building = Instantiate(buildingPrefab);

		building.transform.parent = buildingContainer.transform;
		building.transform.position = buildingPosition;
	}

	private Vector3 GetBuildingPosition(Vector2 gridPosition, out Tile rootTile) {
		Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(gridPosition);

		rootTile = TileStore.getInstance.GetTile(tileCoordinates);

		Vector2Int rootTileCoordinates = rootTile.vertexD.GetCoordinates();

		return new(rootTileCoordinates.x, 0, rootTileCoordinates.y);
	}

	private void InstantiateBuildingHighlight(Vector3 buildingPosition) {
		currentBuildingHighlight = Instantiate(buildingHighlightPrefab);
		currentBuildingHighlight.transform.parent = buildingContainer.transform;
		currentBuildingHighlight.transform.position = buildingPosition;
	}

	private void MoveBuildingHighlight(Vector3 buildingPosition, Tile rootTile) {
		Dictionary<Vector2Int[], Tile> tiles = TileStore.getInstance.GetTileNeighbours(rootTile, new Vector2Int(2, 2));

		currentBuildingHighlight.transform.position = buildingPosition;

		foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
			if (!pair.Value.IsTileBuildable()) {
				Debug.Log("Not buildable!!!");
				break;
			};
		}
	}

}
