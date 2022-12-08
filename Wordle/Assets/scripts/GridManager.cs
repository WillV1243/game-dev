using UnityEngine;

public class GridManager : MonoBehaviour {

	[SerializeField] private GameObject gridPanel;
	[SerializeField] private GameMaster gameMaster;
	[SerializeField] private KeyboardManager keyboardManager;

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

	public void HandleBackPress() {
		if (currentColumn == 0) return;

		currentColumn--;

		Letter cell = grid[currentRow][currentColumn].GetComponent<Letter>();

		cell.RemoveLetterText();
	}

	public void HandleEnterPress() {
		if (currentColumn < 5) return;

		string guessWord = GetWord();
		bool wordNotInList = !gameMaster.IsWordInList(guessWord);

		if (wordNotInList) return;

		SetLetterAndKeyStates();

		if (gameMaster.IsWordCorrect(guessWord)) {
			gameMaster.GameSuccess();
			return;
		}

		if (currentRow >= 5) {
			gameMaster.GameFail();
			return;
		};

		currentRow++;
		currentColumn = 0;
	}

	private void SetLetterAndKeyStates() {
		for (int i = 0; i < grid[currentRow].Length; i++) {
			Letter letter = grid[currentRow][i].GetComponent<Letter>();

			letter.SetState(LetterState.Absent);
			keyboardManager.SetKeyState(letter.GetLetterText(), KeyState.Absent);

			if (gameMaster.IsLetterPresent(letter.GetLetterText())) {
				letter.SetState(LetterState.Present);
				keyboardManager.SetKeyState(letter.GetLetterText(), KeyState.Present);
			}

			if (gameMaster.IsLetterCorrect(letter.GetLetterText(), i)) {
				letter.SetState(LetterState.Correct);
				keyboardManager.SetKeyState(letter.GetLetterText(), KeyState.Correct);
			}
		}
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
