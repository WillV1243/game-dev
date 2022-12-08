using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour {

	[SerializeField] private GameObject letterText;
	[SerializeField] private GameObject letterCell;

	[SerializeField] private Sprite spriteBlank;
	[SerializeField] private Sprite spriteCorrect;
	[SerializeField] private Sprite spriteAbsent;
	[SerializeField] private Sprite spritePresent;

	private LetterState state = LetterState.Blank;

	public void SetLetterText(string letter) {
		TextMeshProUGUI textComponent = letterText.GetComponent<TextMeshProUGUI>();

		textComponent.text = letter;
	}

	public void RemoveLetterText() {
		TextMeshProUGUI textComponent = letterText.GetComponent<TextMeshProUGUI>();

		textComponent.text = "";

		SetState(LetterState.Blank);
	}

	public string GetLetterText() {
		TextMeshProUGUI textComponent = letterText.GetComponent<TextMeshProUGUI>();

		return textComponent.text;
	}

	public void SetState(LetterState newState) {
		if (state == LetterState.Correct) return;

		ChangeSprite(newState);

		state = newState;
	}

	private void ChangeSprite(LetterState state) {
		Image image = letterCell.GetComponent<Image>();

		switch (state) {
			case LetterState.Blank:
				image.sprite = spriteBlank;
				break;

			case LetterState.Correct:
				image.sprite = spriteCorrect;
				break;

			case LetterState.Absent:
				image.sprite = spriteAbsent;
				break;

			case LetterState.Present:
				image.sprite = spritePresent;
				break;
		}
	}

}
