using UnityEngine;

public class Vertex {
	public int x, y;

	public bool isDisabled = true;

	public Vertex(Vector2Int coordinate) {
		x = coordinate.x;
		y = coordinate.y;
	}

	public void Enable() {
		isDisabled = true;
	}

	public Vector2Int GetCoordinates() {
		return new Vector2Int(x, y);
	}
}
