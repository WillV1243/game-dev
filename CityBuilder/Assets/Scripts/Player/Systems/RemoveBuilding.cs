using Buildings;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

	public class RemoveBuilding : PlayerSystemBase {

		private GameObject highlightedBuilding;

		private void Start() {
			player.events.OnRemoveBuilding += HandleRemoveBuilding;
			player.events.OnRemoveBuildingHighlight += HandleRemoveBuildingHighlight;
		}

		private void HandleRemoveBuilding(GameObject buildingRef) {
			Dictionary<Vector2Int[], Tile> tiles = TileStore.getInstance.GetTilesWithBuildingRef(buildingRef);

			Destroy(buildingRef);

			foreach (KeyValuePair<Vector2Int[], Tile> pair in tiles) {
				pair.Value.ChangeState(TileState.Unoccupied);
				pair.Value.buildingRef = null;
			}
		}

		private void HandleRemoveBuildingHighlight(GameObject buildingRef) {
			if (highlightedBuilding == null && buildingRef != null) {

				highlightedBuilding = buildingRef;

				Building buildingBehaviour = highlightedBuilding.GetComponent<Building>();
				buildingBehaviour.ChangeState(Buildings.BuildingState.Removing);

			} else if (highlightedBuilding != buildingRef) {

				Building buildingBehaviour = highlightedBuilding.GetComponent<Building>();
				buildingBehaviour.ChangeState(Buildings.BuildingState.Complete);

				highlightedBuilding = null;

			}
		}
	}

}
