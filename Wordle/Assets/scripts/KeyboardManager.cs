using UnityEngine;

public class KeyboardManager : MonoBehaviour {

	[SerializeField] private GameObject keyboardPanel;

	private GameObject[] keyboard;
	private GridManager gridManager;

	private int currentRow = 0;
	private int currentColumn = 0;

	void Start() {
		keyboard = GetKeyboard();
		gridManager = gameObject.GetComponent<GridManager>();
	}

	public void OnLetterPress(string letter) {
		gridManager.HandleLetterPress(letter);
	}

	public void OnEnterPress() {
		gridManager.HandleEnterPress();
	}

	public void OnBackPress() {
		gridManager.HandleBackPress();
	}

	private GameObject[] GetKeyboard() {
		GameObject[] keyboard = new GameObject[28];

		int keyIndex = 0;

		foreach (Transform row in keyboardPanel.transform) {
			foreach (Transform key in row) {
				keyboard[keyIndex] = key.gameObject;
				keyIndex++;
			}
		}

		return keyboard;
	}
}
