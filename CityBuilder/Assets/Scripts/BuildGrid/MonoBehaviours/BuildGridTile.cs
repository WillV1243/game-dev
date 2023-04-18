using UnityEngine;

public class BuildGridTile : MonoBehaviour {

	[Header("References")]
	public GameObject tileObject;

	[Header("layers")]
	public string tagToMakeTileDisabled;

	[Header("Materials")]
	public Material tileMaterial;
	public Material disabledTileMaterial;

	public Tile tileData;

	private void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.CompareTag(tagToMakeTileDisabled)) {
			tileData.isDisabled = true;

			gameObject.GetComponent<Renderer>().material = disabledTileMaterial;
		}
	}
}
