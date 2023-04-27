using Buildings;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

	public class RemovingState : PlayerStateBase {

		private GameObject highlightedBuilding;

		public override PlayerState GetStateType() {
			return PlayerState.Removing;
		}

		public override void HandleMouseClick(Vector2 gridPosition, HandleMouseClickCallback callback = null) {
			Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(gridPosition);

			Tile rootTile = TileStore.getInstance.GetTile(tileCoordinates);

			if (rootTile.GetState() != TileState.Occupied) {
				callback?.Invoke(false);
				return;
			}

			Dictionary<Vector2Int[], Tile> tiles = TileStore.getInstance.GetTilesWithBuildingRef(rootTile, rootTile.buildingRef);

			Destroy(rootTile.buildingRef);

			foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
				pair.Value.ChangeState(TileState.Unoccupied);
				pair.Value.buildingRef = null;
			}

			callback?.Invoke(true);
		}

		public override void HandleMouseHover(Vector2 gridPosition) {
			Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(gridPosition);

			Tile rootTile = TileStore.getInstance.GetTile(tileCoordinates);

			if (highlightedBuilding == null && rootTile.buildingRef != null) {

				highlightedBuilding = rootTile.buildingRef;

				Building buildingBehaviour = highlightedBuilding.GetComponent<Building>();
				buildingBehaviour.ChangeState(Buildings.BuildingState.Removing);

			} else if (highlightedBuilding != rootTile.buildingRef) {

				Building buildingBehaviour = highlightedBuilding.GetComponent<Building>();
				buildingBehaviour.ChangeState(Buildings.BuildingState.Complete);

				highlightedBuilding = null;

			}
		}

	}

}
