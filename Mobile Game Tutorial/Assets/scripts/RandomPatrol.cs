using UnityEngine;

public class RandomPatrol : MonoBehaviour {

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	Vector2 targetPosition;

	public float speed;

	// Start is called before the first frame update
	void Start() {
		targetPosition = GetRandomPosition();
	}

	// Update is called once per frame
	void Update() {
		if ((Vector2)transform.position != targetPosition) {
			transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
		} else {
			targetPosition = GetRandomPosition();
		}
	}

	Vector2 GetRandomPosition() {
		float randomX = Random.Range(minX, maxX);
		float randomY = Random.Range(minY, maxY);

		return new Vector2(randomX, randomY);
	}

}
