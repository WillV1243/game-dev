using System;
using UnityEngine;

public class KeyboardManager : MonoBehaviour {

	[SerializeField] private GameObject keyboardPanel;
	[SerializeField] private GameMaster gameMaster;

	private GameObject[] keyboard;
	private GridManager gridManager;

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

	public void SetKeyState(string letter, KeyState newState) {
		Key key = GetKeyFromLetterText(letter).GetComponent<Key>();

		key.SetState(newState);
	}

	private GameObject GetKeyFromLetterText(string letter) {
		return Array.Find<GameObject>(keyboard, listKey => {
			Key keyboardKey = listKey.GetComponent<Key>();
			string letterText = keyboardKey.GetLetterText();

			return letterText == letter;
		});
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
