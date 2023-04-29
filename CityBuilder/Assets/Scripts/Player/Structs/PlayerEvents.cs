using System;
using UnityEngine;

namespace Player {

	public struct PlayerEvents {

		// Input Events
		public Action<Vector3> OnMouseLeftClick, OnMouseLeftHold, OnMouseLeftUp;
		public Action<Vector3> OnMouseRightClick, OnMouseRightHold, OnMouseRightUp;
		public Action<Vector3> OnMouseHover;
		public Action OnMoveForward, OnMoveRight, OnMoveBack, OnMoveLeft;
		public Action OnRotateRight, OnRotateLeft;
		public Action OnZoomIn, OnZoomOut;

		// State Events
		public Action<PlayerState[]> OnChangePlayerState;

		// Building Events
		public Action OnConstructBuilding;
		public Action OnRemoveBuilding;
		public Action OnSelectBuilding;

	}

}
