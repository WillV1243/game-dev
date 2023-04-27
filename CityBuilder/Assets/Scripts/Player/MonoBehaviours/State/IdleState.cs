using UnityEngine;

namespace Player {

	public class IdleState : PlayerStateBase {

		public override PlayerState GetStateType() {
			return PlayerState.Idle;
		}

		public override void HandleMouseClick(Vector2 gridPosition, HandleMouseClickCallback callback = null) { }

		public override void HandleMouseHover(Vector2 gridPosition) { }

	}

}
