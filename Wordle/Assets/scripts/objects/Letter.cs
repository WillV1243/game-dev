using TMPro;
using UnityEngine;

public class Letter : MonoBehaviour {

	[SerializeField] private GameObject letterText;
	[SerializeField] private GameObject letterCell;

	private LetterState state = LetterState.Blank;

	public void SetLetterText(string letter) {
		TextMeshProUGUI textComponent = letterText.GetComponent<TextMeshProUGUI>();

		textComponent.text = letter;

		SetState(LetterState.Filled);
	}

	public void RemoveLetter() {
		TextMeshProUGUI textComponent = letterText.GetComponent<TextMeshProUGUI>();

		textComponent.text = "";

		SetState(LetterState.Blank);
	}

	public string GetLetterText() {
		TextMeshProUGUI textComponent = letterText.GetComponent<TextMeshProUGUI>();

		return textComponent.text;
	}

	public void SetState(LetterState newState) {
		state = newState;
	}

}
