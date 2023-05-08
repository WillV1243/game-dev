namespace Player {

	public class CursorBehaviour : PlayerSystemBase {

		void Start() {
			player.events.OnMouseLeftClick += HandleMouseClick;
			player.events.OnMouseMiddleClick += HandleMouseMiddleClick;
			player.events.OnMouseHover += HandleMouseHover;
		}

		private void HandleMouseClick(CursorTarget cursorTarget) {
			player.cursor.HandleMouseClick(cursorTarget);
		}

		private void HandleMouseHover(CursorTarget cursorTarget) {
			player.cursor.HandleMouseHover(cursorTarget);
		}

		private void HandleMouseMiddleClick(CursorTarget cursorTarget) {
			player.cursor.HandleMouseMiddleClick(cursorTarget);
		}

	}

}
