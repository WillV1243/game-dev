public class Edge {
	public Vertex vertexA, vertexB;

	public bool isDisabled = true;

	public Edge(Vertex vertexA, Vertex vertexB) {
		this.vertexA = vertexA;
		this.vertexB = vertexB;
	}

	public void Enable() {
		isDisabled = false;
	}

}
