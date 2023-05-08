using Player;
using UnityEngine;

public class UIManager : MonoBehaviour {

	[Header("References")]
	public PlayerManager player;

	public void ChangePlayerStateBuilding(int building) {
		player.ChangeConstructingBuilding(building);

		player.ChangeCursorState(CursorState.Building);
	}

	public void ChangePlayerStateRemoving() {
		player.ChangeCursorState(CursorState.Removing);
	}

}
