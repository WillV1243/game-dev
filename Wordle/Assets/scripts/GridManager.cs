using UnityEngine;

public class GridManager : MonoBehaviour {

	[SerializeField] private GameObject gridPanel;

	private GameObject[][] grid;

	private int currentRow = 0;
	private int currentColumnm = 0;

	void Start() {
		grid = GetGrid();
	}

	private GameObject[][] GetGrid() {
		grid = new GameObject[6][];

		for (int i = 0; i < grid.Length; i++) {
			grid[i] = new GameObject[5];
		}

		for (int i = 0; i < gridPanel.transform.childCount; i++) {
			for (int j = 0; j < gridPanel.transform.GetChild(i).childCount; j++) {
				Transform row = gridPanel.transform.GetChild(i);

				grid[i][j] = row.GetChild(j).gameObject;

				Letter letterComponent = row.GetChild(j).gameObject.GetComponent<Letter>();
			}
		}

		return grid;
	}
}
