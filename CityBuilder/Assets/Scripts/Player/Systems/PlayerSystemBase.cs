using UnityEngine;

namespace Player {

	public abstract class PlayerSystemBase : MonoBehaviour {

		protected PlayerManager player;

		protected virtual void Awake() {
			player = transform.root.GetComponent<PlayerManager>();
		}
	}

}
