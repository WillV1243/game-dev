namespace Player {

	public abstract class CursorStateBase : PlayerSystemBase {
		public abstract CursorState State { get; }

		public abstract void HandleMouseClick(CursorTarget cursorTarget);

		public abstract void HandleMouseHover(CursorTarget cursorTarget);

		public abstract void HandleMouseMiddleClick(CursorTarget cursorTarget);
	}

}
