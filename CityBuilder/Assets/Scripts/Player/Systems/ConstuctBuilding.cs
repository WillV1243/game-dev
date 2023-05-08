using Buildings;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

	public class ConstuctBuilding : PlayerSystemBase {

		[Header("Settings")]
		public BuildingRotation currentBuildingRotation = BuildingRotation.Down;

		private GameObject currentBuilding;

		private void Start() {
			player.events.OnChangeCursorState += HandleDestoryBuilding;

			player.events.OnConstructBuilding += HandleContructBuilding;
			player.events.OnRotateBuilding += HandleRotateBuilding;
			player.events.OnConstructBuildingHighlight += HandleConstructBuildingHighlight;
		}

		private void HandleDestoryBuilding(CursorState[] states) {
			if (states[0] == CursorState.Building) return;

			if (currentBuilding == null) return;

			Destroy(currentBuilding);
			currentBuilding = null;
		}

		private void HandleContructBuilding(BuildingBlueprint blueprint) {
			BuildingRotation? rotation = blueprint.Rotation ?? currentBuildingRotation;

			// TODO Change GetTileNeighbours to handle rotation
			Dictionary<Vector2Int[], Tile> tiles = TileStore.getInstance.GetTileNeighbours(blueprint.RootTile, new Vector2Int(2, 2));

			foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
				if (!pair.Value.IsTileBuildable()) {
					return;
				};
			}

			currentBuilding.GetComponent<Building>().ChangeState(Buildings.BuildingState.Complete);

			foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
				pair.Value.ChangeState(TileState.Occupied);
				pair.Value.buildingRef = currentBuilding;
			}

			currentBuilding = null;

			player.ChangeCursorState(CursorState.Idle);
		}

		private void HandleRotateBuilding() {
			int currentIndex = (int)currentBuildingRotation;

			int rotationsLength = Enum.GetValues(typeof(BuildingRotation)).Length;
			int nextRotation = (currentIndex + 1) % rotationsLength;

			currentBuildingRotation = (BuildingRotation)nextRotation;

			// TODO then cause rotation in gameobject
		}

		private void HandleConstructBuildingHighlight(Vector2 gridPosition) {
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
			currentBuilding = Instantiate(player.references.buildings[0]);

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
