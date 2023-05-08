using UnityEngine;

namespace Player {

	public class CursorTarget {
		public RaycastHit Hit { get; set; }
		public Vector2 GridPosition { get; set; }
		public string Layer { get; set; }

		public CursorTarget(RaycastHit hit) {
			Hit = hit;

			GridPosition = new Vector2(hit.point.x, hit.point.z);
			Layer = LayerMask.LayerToName(hit.transform.gameObject.layer);
		}
	}

}