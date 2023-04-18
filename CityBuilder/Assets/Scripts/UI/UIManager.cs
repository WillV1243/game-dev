using UnityEngine;

public class UIManager : MonoBehaviour {

	[Header("References")]
	public PlayerManager playerManager;

	public void ChangePlayerStateTile() {
		playerManager.ChangeState(PlayerState.TileBuilding);
	}

	public void ChangePlayerStatePath() {
		playerManager.ChangeState(PlayerState.PathBuilding);
	}

	public void ChangePlayerStateNode() {
		playerManager.ChangeState(PlayerState.NodeBuilding);
	}

}
