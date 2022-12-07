using System;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	[SerializeField] private TextAsset wordsList;

	private string[] words;
	private string word;

	// Start is called before the first frame update
	void Start() {
		words = JsonUtility.FromJson<Words>(wordsList.text).words;
		word = GetRandomWord();
	}

	public void GameSuccess() {

	}

	public void GameFail() {

	}

	public bool IsWordInList(string word) {
		return Array.Exists<string>(words, listWord => listWord == word);
	}

	private string GetRandomWord() {
		int randomIndex = UnityEngine.Random.Range(0, words.Length - 1);

		return words[randomIndex];
	}
}
