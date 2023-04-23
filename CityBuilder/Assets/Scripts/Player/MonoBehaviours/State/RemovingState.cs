using UnityEngine;

public class RemovingState : PlayerStateBase {

	public override PlayerState GetStateType() {
		return PlayerState.Removing;
	}

	public override void HandleMouseClick(Vector2 gridPosition, HandleMouseClickCallback callback = null) { }

	public override void HandleMouseHover(Vector2 gridPosition) { }

}
