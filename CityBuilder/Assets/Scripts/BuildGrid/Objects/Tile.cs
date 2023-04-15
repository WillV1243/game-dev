public class Tile {
	/*
								AB
					A             B
						* ------- *
						|         |
			AD    |					|    BC
						|					|
						* ------- *
					D             C	
								DC
	*/
	public Vertex vertexA;
	public Vertex vertexB;
	public Vertex vertexC;
	public Vertex vertexD;

	public Edge edgeAB;
	public Edge edgeBC;
	public Edge edgeDC;
	public Edge edgeAD;

	public Tile(Vertex[] vertices, Edge[] edges) {
		vertexA = vertices[0];
		vertexB = vertices[1];
		vertexC = vertices[2];
		vertexD = vertices[3];

		edgeAB = edges[0];
		edgeBC = edges[1];
		edgeDC = edges[2];
		edgeAD = edges[3];
	}
}
