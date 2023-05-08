using System.Collections.Generic;
using UnityEngine;

namespace Player {

	public class PlayerManager : MonoBehaviour {

		public PlayerReferences references;
		public PlayerEvents events;

		public CursorStateBase cursor;

		public BuildingType constructingBuilding;
		public GameObject selectedBuilding;

		private void Awake() {
			cursor = GetComponent<CursorStateBase>();

			InitializeBuildingPrefabs();
		}

		private void InitializeBuildingPrefabs() {
			references.buildings = new List<GameObject>(Resources.LoadAll<GameObject>("Buildings"));
		}

		public void ChangeCursorState(CursorState state) {
			if (state == cursor.State) return;

			events.OnChangeCursorState?.Invoke(new CursorState[2] { state, GetComponent<CursorStateBase>().State });

			Destroy(GetComponent<CursorStateBase>());

			switch (state) {
				case CursorState.Idle:
					cursor = gameObject.AddComponent<IdleState>();
					break;

				case CursorState.Building:
					cursor = gameObject.AddComponent<BuildingState>();
					break;

				case CursorState.Removing:
					cursor = gameObject.AddComponent<RemovingState>();
					break;
			}
		}

		public void ChangeConstructingBuilding(int buildingKey) {
			constructingBuilding = (BuildingType)buildingKey;
		}

	}

}