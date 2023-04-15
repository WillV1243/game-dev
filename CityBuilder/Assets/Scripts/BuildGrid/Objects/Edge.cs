public class Edge {
	public Vertex vertexA;
	public Vertex vertexB;

	public bool isOuterEdge;

	public Edge(Vertex vertexA, Vertex vertexB) {
		this.vertexA = vertexA;
		this.vertexB = vertexB;
	}
}
