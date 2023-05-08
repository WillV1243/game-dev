using System;
using UnityEngine;

namespace Player {

	public struct PlayerEvents {

		// Input Events
		public Action<CursorTarget> OnMouseLeftClick, OnMouseLeftHold, OnMouseLeftUp;
		public Action<CursorTarget> OnMouseRightClick, OnMouseRightHold, OnMouseRightUp;
		public Action<CursorTarget> OnMouseMiddleClick, OnMouseMiddleHold, OnMouseMiddleUp;
		public Action<CursorTarget> OnMouseHover;
		public Action OnMoveForward, OnMoveRight, OnMoveBack, OnMoveLeft;
		public Action OnRotateRight, OnRotateLeft;
		public Action OnZoomIn, OnZoomOut;

		// State Events
		public Action<CursorState[]> OnChangeCursorState;

		// Building Events
		public Action<BuildingBlueprint> OnConstructBuilding;
		public Action<Vector2> OnConstructBuildingHighlight;
		public Action OnRotateBuilding;

		public Action<GameObject> OnRemoveBuilding;
		public Action<GameObject> OnRemoveBuildingHighlight;

		public Action OnSelectBuilding;

	}

}
