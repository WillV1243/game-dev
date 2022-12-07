using UnityEngine;

public class DragAndDrop : MonoBehaviour {

	Collider2D objectCollider;
	bool moveAllowed;

	// Start is called before the first frame update
	void Start() {
		objectCollider = GetComponent<Collider2D>();
	}

	// Update is called once per frame
	void Update() {
		if (Input.touchCount > 0) {
			Touch touch = Input.GetTouch(0);
			Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

			if (touch.phase == TouchPhase.Began) {
				Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);

				if (objectCollider = touchedCollider) {
					moveAllowed = true;
					Debug.Log("Touch detected");
				}
			}

			if (touch.phase == TouchPhase.Moved) {
				if (moveAllowed) {
					transform.position = new Vector2(touchPosition.x, touchPosition.y);
				}
			}

			if (touch.phase == TouchPhase.Ended) {
				moveAllowed = false;
			}
		}
	}
}
