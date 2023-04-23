using UnityEngine;

public class Edge {
	public Vertex vertexA, vertexB;

	public bool isDisabled = true;

	public Edge(Vertex vertexA, Vertex vertexB) {
		this.vertexA = vertexA;
		this.vertexB = vertexB;
	}

	public void Enable() {
		isDisabled = false;

		Vector3 start = new(vertexA.x, 0.05f, vertexA.y);
		Vector3 end = new(vertexB.x, 0.05f, vertexB.y);

		Debug.DrawLine(start, end, Color.blue, 50000);
	}

}
