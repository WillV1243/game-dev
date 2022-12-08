using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour {

	[SerializeField] private GameObject keyText;
	[SerializeField] private GameObject keyButton;

	[SerializeField] private Sprite spriteNotUsed;
	[SerializeField] private Sprite spriteCorrect;
	[SerializeField] private Sprite spriteAbsent;
	[SerializeField] private Sprite spritePresent;

	private KeyState state = KeyState.NotUsed;

	public string GetLetterText() {
		return keyText.GetComponent<TextMeshProUGUI>().text;
	}

	public void SetState(KeyState newState) {
		ChangeSprite(newState);

		state = newState;
	}

	private void ChangeSprite(KeyState state) {
		Image image = keyButton.GetComponent<Image>();
		Button button = keyButton.GetComponent<Button>();

		switch (state) {
			case KeyState.NotUsed:
				image.sprite = spriteNotUsed;
				button.enabled = true;
				break;

			case KeyState.Correct:
				image.sprite = spriteCorrect;
				button.enabled = true;
				break;

			case KeyState.Absent:
				image.sprite = spriteAbsent;
				button.enabled = false;
				break;

			case KeyState.Present:
				image.sprite = spritePresent;
				button.enabled = true;
				break;
		}
	}

}
