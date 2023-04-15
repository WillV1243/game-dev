using System.Linq;
using UnityEngine;

public class GridManager : MonoBehaviour {

	[Header("Grid Settings")]
	public int gridSizeX = 100;
	public int gridSizeZ = 100;
	public int tileSize = 1;
	public int gridOffsetX = 0;
	public int gridOffsetZ = 0;

	private TileStore tileStore;
	private EdgeStore edgeStore;
	private VertexStore vertexStore;

	private void Start() {
		InitializeGrid();
	}

	private void InitializeGrid() {
		CreateVertexStore();
		CreateEdgeStore();
		CreateTileStore();

		Debug.Log(vertexStore.GetVertices().Count);
		Debug.Log(edgeStore.GetEdges().Count);
		Debug.Log(tileStore.GetTiles().Count);
	}

	private void CreateVertexStore() {
		vertexStore = VertexStore.getInstance;

		for (int z = gridOffsetZ; z < gridOffsetZ + gridSizeZ; z++) {
			for (int x = gridOffsetX; x < gridOffsetX + gridSizeX; x++) {

				Vector3 coordinate = new Vector3(x, 0, z);
				vertexStore.AddVertex(coordinate);

			}
		}
	}

	private void CreateEdgeStore() {
		edgeStore = EdgeStore.getInstance;

		for (int z = gridOffsetZ; z < gridOffsetZ + gridSizeZ; z++) {
			for (int x = gridOffsetX; x < gridOffsetX + gridSizeX; x++) {
				/*
				 
															B
									* * * * * |
									*         |		Creating BC and DC for
									*					|     each vertex in grid
									*					|
									----------*  <--- current vertex
								D             C	
		
				*/
				Vertex vertexB = vertexStore.GetVertex(new Vector3(x, 0, z - 1));
				Vertex vertexC = vertexStore.GetVertex(new Vector3(x, 0, z)); // current vertex
				Vertex vertexD = vertexStore.GetVertex(new Vector3(x - 1, 0, z));

				if (vertexB != null && vertexC != null) {
					Vertex[] verticalEdge = new Vertex[2] { vertexB, vertexC };

					edgeStore.AddEdge(verticalEdge);
				}

				if (vertexD != null && vertexC != null) {
					Vertex[] horizontalEdge = new Vertex[2] { vertexD, vertexC };

					edgeStore.AddEdge(horizontalEdge);
				}
			}
		}
	}

	private void CreateTileStore() {
		tileStore = TileStore.getInstance;

		for (int z = gridOffsetZ; z < gridOffsetZ + gridSizeZ; z++) {
			for (int x = gridOffsetX; x < gridOffsetX + gridSizeX; x++) {
				/*
											AB
								A             B
									* ------- *
									|         |
						AD    |					|    BC
									|					|
									* ------- *  <--- current vertex
								D             C	
											CD
				*/
				Vector3 A = new Vector3(x - 1, 0, z - 1);
				Vector3 B = new Vector3(x, 0, z - 1);
				Vector3 C = new Vector3(x, 0, z); // current vertex
				Vector3 D = new Vector3(x - 1, 0, z);

				Vertex vertexA = vertexStore.GetVertex(A);
				Vertex vertexB = vertexStore.GetVertex(B);
				Vertex vertexC = vertexStore.GetVertex(C);
				Vertex vertexD = vertexStore.GetVertex(D);

				Vertex[] AB = new Vertex[2] { vertexA, vertexB };
				Vertex[] BC = new Vertex[2] { vertexB, vertexC };
				Vertex[] CD = new Vertex[2] { vertexC, vertexD };
				Vertex[] AD = new Vertex[2] { vertexA, vertexD };

				Edge edgeAB = edgeStore.GetEdge(AB);
				Edge edgeBC = edgeStore.GetEdge(BC);
				Edge edgeCD = edgeStore.GetEdge(CD);
				Edge edgeAD = edgeStore.GetEdge(AD);

				Vertex[] vertices = new Vertex[4] { vertexA, vertexB, vertexC, vertexD };
				Edge[] edges = new Edge[4] { edgeAB, edgeBC, edgeCD, edgeAD };

				if (vertices.Contains(null) || edges.Contains(null)) continue;

				Vector3 coordinates = new Vector3(x - 1, 0, z - 1);

				tileStore.AddTile(coordinates, vertices, edges);
			}
		}
	}

}
