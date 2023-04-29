using UnityEngine;

namespace Player {

	public abstract class PlayerStateBase : PlayerSystemBase {
		public abstract PlayerState GetStateType();

		public delegate void HandleMouseClickCallback(bool success);

		public abstract void HandleMouseClick(Vector2 gridPosition, HandleMouseClickCallback callback = null);

		public abstract void HandleMouseHover(Vector2 gridPosition);
	}

}
