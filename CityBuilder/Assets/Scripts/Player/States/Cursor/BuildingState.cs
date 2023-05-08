using UnityEngine;

namespace Player {

	public class BuildingState : CursorStateBase {

		public override CursorState State {
			get { return CursorState.Building; }
		}

		public override void HandleMouseClick(CursorTarget cursorTarget) {
			Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(cursorTarget.GridPosition);

			Tile rootTile = TileStore.getInstance.GetTile(tileCoordinates);
			BuildingType buildingType = player.constructingBuilding;

			BuildingBlueprint blueprint = new(rootTile, buildingType);

			player.events.OnConstructBuilding?.Invoke(blueprint);
		}

		public override void HandleMouseHover(CursorTarget cursorTarget) {
			player.events.OnConstructBuildingHighlight?.Invoke(cursorTarget.GridPosition);
		}

		public override void HandleMouseMiddleClick(CursorTarget cursorTarget) {
			player.events.OnRotateBuilding?.Invoke();
		}

	}

}
