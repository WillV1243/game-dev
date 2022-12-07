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

	// Update is called once per frame
	void Update() {

	}

	private string GetRandomWord() {
		int randomIndex = Random.Range(0, words.Length - 1);

		return words[randomIndex];
	}
}
