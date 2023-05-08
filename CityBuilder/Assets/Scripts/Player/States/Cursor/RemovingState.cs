using UnityEngine;

namespace Player {

	public class RemovingState : CursorStateBase {

		public override CursorState State {
			get { return CursorState.Removing; }
		}

		public override void HandleMouseClick(CursorTarget cursorTarget) {
			switch (cursorTarget.Layer) {

				case "Buildings":
					GameObject buildingRef = cursorTarget.Hit.transform.gameObject;

					player.events.OnRemoveBuilding?.Invoke(buildingRef);

					return;

				case "BuildGrid":
					Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(cursorTarget.GridPosition);
					Tile rootTile = TileStore.getInstance.GetTile(tileCoordinates);

					if (rootTile.GetState() != TileState.Occupied) return;

					player.events.OnRemoveBuilding?.Invoke(rootTile.buildingRef);

					return;

			}
		}

		public override void HandleMouseHover(CursorTarget cursorTarget) {
			switch (cursorTarget.Layer) {

				case "Buildings":
					GameObject buildingRef = cursorTarget.Hit.transform.gameObject;

					player.events.OnRemoveBuildingHighlight?.Invoke(buildingRef);

					return;

				case "BuildGrid":
					Vector2Int[] tileCoordinates = PlayerUtils.GetTileCoordinates(cursorTarget.GridPosition);
					Tile rootTile = TileStore.getInstance.GetTile(tileCoordinates);

					player.events.OnRemoveBuildingHighlight?.Invoke(rootTile?.buildingRef);

					return;

			}

		}

		public override void HandleMouseMiddleClick(CursorTarget cursorTarget) { }

	}

}
