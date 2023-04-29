using UnityEngine;

namespace Player {

	public class CursorBehaviour : PlayerSystemBase {

		void Start() {
			player.events.OnMouseLeftClick += HandleMouseClick;
			player.events.OnMouseHover += HandleMouseHover;
		}

		private void HandleMouseClick(Vector3 position) {
			Vector2 gridPosition = new(position.x, position.z);

			player.GetState().HandleMouseClick(gridPosition, (bool success) => {
				if (success) player.ChangeState(PlayerState.Idle);
			});
		}

		private void HandleMouseHover(Vector3 position) {
			Vector2 gridPosition = new(position.x, position.z);

			player.GetState().HandleMouseHover(gridPosition);
		}

	}

}
