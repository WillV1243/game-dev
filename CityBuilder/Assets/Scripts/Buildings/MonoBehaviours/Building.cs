using UnityEngine;

namespace Buildings {

	public class Building : MonoBehaviour {
		[Header("Materials")]
		public Material buildingMaterial;
		public Material buildingHighlight;
		public Material buildingRemove;

		[Header("References")]
		public GameObject buildingRef;

		private BuildingState buildingState = BuildingState.Highlight;

		public void ChangeState(BuildingState state) {
			if (state == buildingState) return;

			buildingState = state;

			ChangeMaterial();
		}

		private void ChangeMaterial() {
			Renderer renderer = buildingRef.GetComponent<Renderer>();

			switch (buildingState) {
				case BuildingState.Highlight:
					renderer.material = buildingHighlight;
					break;

				case BuildingState.Removing:
					renderer.material = buildingRemove;
					break;

				case BuildingState.Complete:
					renderer.material = buildingMaterial;
					break;
			}
		}
	}

}