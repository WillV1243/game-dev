using System;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	[SerializeField] private TextAsset wordsList;

	private string[] words;
	private string word;

	void Start() {
		words = JsonUtility.FromJson<Words>(wordsList.text).words;
		word = GetRandomWord();
	}

	public void GameSuccess() {
		// TODO show splash if successful then option to reload game
	}

	public void GameFail() {
		// TODO show splash if fail then option to reload game
	}

	public bool IsWordCorrect(string word) {
		return this.word == word;
	}

	public bool IsWordInList(string word) {
		return Array.Exists<string>(words, listWord => listWord == word);
	}

	public bool IsLetterPresent(string letter) {
		char[] lettersInGoalWord = word.ToCharArray();

		return Array.Exists<char>(lettersInGoalWord, listLetter => listLetter == letter.ToLower()[0]);
	}

	public bool IsLetterCorrect(string letter, int position) {
		return word[position] == letter.ToLower()[0];
	}

	private string GetRandomWord() {
		int randomIndex = UnityEngine.Random.Range(0, words.Length - 1);

		return words[randomIndex];
	}
}
