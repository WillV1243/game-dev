using Buildings;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

	public class BuildingState : PlayerStateBase {

		private GameObject currentBuilding;

		private void OnDestroy() {
			if (currentBuilding != null) Destroy(currentBuilding);
		}

		public override PlayerState GetStateType() {
			return PlayerState.Building;
		}

		public override void HandleMouseClick(Vector2 gridPosition, HandleMouseClickCallback callback = null) {
			Vector3 buildingPosition = GetBuildingPosition(gridPosition, out Tile rootTile);

			Dictionary<Vector2Int[], Tile> tiles = TileStore.getInstance.GetTileNeighbours(rootTile, new Vector2Int(2, 2));

			foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
				if (!pair.Value.IsTileBuildable()) {
					callback?.Invoke(false);
					return;
				};
			}

			currentBuilding.GetComponent<Building>().ChangeState(Buildings.BuildingState.Complete);

			foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
				pair.Value.ChangeState(TileState.Occupied);
				pair.Value.buildingRef = currentBuilding;
			}

			currentBuilding = null;

			callback?.Invoke(true);
		}

		public override void HandleMouseHover(Vector2 gridPosition) {
			Vector3 buildingPosition = GetBuildingPosition(gridPosition, out Tile rootTile);

			if (currentBuilding == null) {

				InstantiateBuilding(gridPosition);

			} else if (currentBuilding.transform.position != buildingPosition) {

				MoveBuildingHighlight(buildingPosition, rootTile);

			}
		}

		private Vector3 GetBuildingPosition(Vector2 gridPosition, out Tile rootTile) {
			Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(gridPosition);

			rootTile = TileStore.getInstance.GetTile(tileCoordinates);

			Vector2Int rootTileCoordinates = rootTile.vertexD.GetCoordinates();

			return new(rootTileCoordinates.x, 0, rootTileCoordinates.y);
		}

		private void InstantiateBuilding(Vector3 buildingPosition) {
			currentBuilding = Instantiate(player.references.buildingPrefab);

			currentBuilding.transform.parent = player.references.buildingContainer.transform;
			currentBuilding.transform.position = buildingPosition;
		}

		private void MoveBuildingHighlight(Vector3 buildingPosition, Tile rootTile) {
			Dictionary<Vector2Int[], Tile> tiles = TileStore.getInstance.GetTileNeighbours(rootTile, new Vector2Int(2, 2));

			currentBuilding.transform.position = buildingPosition;

			foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
				if (!pair.Value.IsTileBuildable()) {
					currentBuilding.GetComponent<Building>().ChangeState(Buildings.BuildingState.Removing);
					return;
				};
			}

			currentBuilding.GetComponent<Building>().ChangeState(Buildings.BuildingState.Highlight);
		}

	}

}
