using Player;
using UnityEngine;

public class UIManager : MonoBehaviour {

	[Header("References")]
	public PlayerManager player;

	public void ChangePlayerStateBuilding() {
		player.ChangeState(PlayerState.Building);
	}

	public void ChangePlayerStateRemoving() {
		player.ChangeState(PlayerState.Removing);
	}

}
