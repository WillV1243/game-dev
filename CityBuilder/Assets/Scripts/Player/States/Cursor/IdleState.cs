namespace Player {

	public class IdleState : CursorStateBase {

		public override CursorState State {
			get { return CursorState.Idle; }
		}

		public override void HandleMouseClick(CursorTarget cursorTarget) { }

		public override void HandleMouseHover(CursorTarget cursorTarget) { }

		public override void HandleMouseMiddleClick(CursorTarget cursorTarget) { }

	}

}
