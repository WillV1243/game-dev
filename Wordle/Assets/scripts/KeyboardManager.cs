using UnityEngine;

public class KeyboardManager : MonoBehaviour {

	[SerializeField] private GameObject keyboardPanel;

	private GameObject[] keyboard;

	private int currentRow = 0;
	private int currentColumn = 0;

	void Start() {
		keyboard = GetKeyboard();
	}

	private GameObject[] GetKeyboard() {
		GameObject[] keyboard = new GameObject[26];

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
