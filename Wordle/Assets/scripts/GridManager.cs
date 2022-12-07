using UnityEngine;

public class GridManager : MonoBehaviour {

	[SerializeField] private GameObject gridPanel;
	[SerializeField] private GameMaster gameMaster;

	private GameObject[][] grid;

	private int currentRow = 0;
	private int currentColumn = 0;

	void Start() {
		grid = GetGrid();
	}

	public void HandleLetterPress(string letter) {
		if (currentColumn >= 5) return;

		Letter cell = grid[currentRow][currentColumn].GetComponent<Letter>();

		cell.SetLetterText(letter.ToUpper());

		currentColumn++;
	}

	public void HandleEnterPress() {
		if (currentColumn < 5 || currentRow >= 6) return;

		bool wordNotInList = !gameMaster.IsWordInList(GetWord());

		if (wordNotInList) return;

		// TODO correct word check
		// TODO determine letter matches
		// TODO change letter state of previous row

		currentRow++;
		currentColumn = 0;
	}

	public void HandleBackPress() {
		if (currentColumn == 0) return;

		currentColumn--;

		Letter cell = grid[currentRow][currentColumn].GetComponent<Letter>();

		cell.RemoveLetter();
	}

	private string GetWord() {
		if (currentColumn < 5) return "";

		string word = "";

		for (int i = 0; i < grid[currentRow].Length; i++) {
			Letter letter = grid[currentRow][i].GetComponent<Letter>();

			word += letter.GetLetterText();
		}

		return word.ToLower();
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
			}
		}

		return grid;
	}
}
