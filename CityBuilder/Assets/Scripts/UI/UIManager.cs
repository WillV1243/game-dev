using Player;
using UnityEngine;

public class UIManager : MonoBehaviour {

	[Header("References")]
	public PlayerManager playerManager;

	public void ChangePlayerStateBuilding() {
		playerManager.ChangeState(PlayerState.Building);
	}

	public void ChangePlayerStateRemoving() {
		playerManager.ChangeState(PlayerState.Removing);
	}

}
