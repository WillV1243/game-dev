using System;
using UnityEngine;

namespace Player {

	[Serializable]
	public struct PlayerReferences {

		[Header("Containers")]
		public GameObject buildingContainer;

		[Header("Prefabs")]
		public GameObject buildingPrefab;

	}

}