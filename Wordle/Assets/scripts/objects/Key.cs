using TMPro;
using UnityEngine;

public class Key : MonoBehaviour {

	[SerializeField] private GameObject keyText;
	[SerializeField] private GameObject keyButton;

	private KeyState state = KeyState.NotUsed;

	public void SetState(KeyState newState) {
		state = newState;
	}

	public string GetLetter() {
		return keyText.GetComponent<TextMeshProUGUI>().text;
	}

}
