using UnityEngine;

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
	public Vertex vertexA, vertexB, vertexC, vertexD;
	public Edge edgeAB, edgeBC, edgeDC, edgeAD;

	public GameObject buildingRef = null;

	private TileState tileState = TileState.Disabled;

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

	public TileState GetState() {
		return tileState;
	}

	public void ChangeState(TileState state, GameObject buildingRef = null) {
		tileState = state;

		if (state == TileState.Occupied && buildingRef) this.buildingRef = buildingRef;
	}

	public Vertex[] GetVertices() {
		return new Vertex[4] { vertexA, vertexB, vertexC, vertexD };
	}

	public Edge[] GetEdges() {
		return new Edge[4] { edgeAB, edgeBC, edgeDC, edgeAD };
	}

	public bool IsTileBuildable() {
		return tileState == TileState.Unoccupied;
	}

	public void Enable() {
		ChangeState(TileState.Unoccupied);

		vertexA.Enable();
		vertexB.Enable();
		vertexC.Enable();
		vertexD.Enable();

		edgeAB.Enable();
		edgeBC.Enable();
		edgeDC.Enable();
		edgeAD.Enable();
	}

	public override string ToString() {
		string label = "Tile | ";

		foreach (Vertex vertex in GetVertices()) {
			label += vertex.GetCoordinates().ToString() + " ";
		}

		return label + " State: " + tileState.ToString();
	}
}
