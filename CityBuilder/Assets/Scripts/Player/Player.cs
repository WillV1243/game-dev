using UnityEngine;

namespace Player {

	public class Player : MonoBehaviour {

		public PlayerReferences references;
		public PlayerEvents events;

		private PlayerStateBase playerState;

		public void ChangeState(PlayerState state) {
			if (state == playerState.GetStateType()) return;

			events.OnChangePlayerState?.Invoke(new PlayerState[2] { state, GetComponent<PlayerStateBase>().GetStateType() });

			Destroy(GetComponent<PlayerStateBase>());

			switch (state) {
				case PlayerState.Idle:
					playerState = gameObject.AddComponent<IdleState>();
					break;

				case PlayerState.Building:
					playerState = gameObject.AddComponent<BuildingState>();
					break;

				case PlayerState.Removing:
					playerState = gameObject.AddComponent<RemovingState>();
					break;
			}
		}

	}

}