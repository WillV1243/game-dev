using System;
using UnityEngine;

namespace Player {

	[Serializable]
	public struct PlayerReferences {

		[Header("Cameras")]
		public Camera mainCamera;

		[Header("Containers")]
		public GameObject buildingContainer;

		[Header("Prefabs")]
		public GameObject buildingPrefab;

	}

}