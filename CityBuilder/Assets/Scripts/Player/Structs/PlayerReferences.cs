using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player {

	[Serializable]
	public struct PlayerReferences {

		[Header("Cameras")]
		public Camera mainCamera;

		[Header("Containers")]
		public GameObject buildingContainer;

		[Header("Prefabs")]
		public List<GameObject> buildings;

	}

}