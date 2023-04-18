using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour {

	[Header("Grid Settings")]
	public int gridSizeX = 100;
	public int gridSizeZ = 100;
	public float tileSize = 1f;
	public int gridOffsetX = 0;
	public int gridOffsetZ = 0;

	[Header("References")]
	public GameObject tilePrefab;
	public Transform gridContainer;

	[Header("Materials")]
	public Material tileMaterial;
	public Material disabledTileMaterial;

	private TileStore tileStore;
	private EdgeStore edgeStore;
	private VertexStore vertexStore;

	private void Start() {
		InitializeGrid();

		CreateGrid();
	}

	private void InitializeGrid() {
		CreateVertexStore();
		CreateEdgeStore();
		CreateTileStore();
	}

	private void CreateGrid() {
		tileStore = TileStore.getInstance;

		foreach (KeyValuePair<Vector2Int, Tile> pair in tileStore.GetTiles()) {
			GameObject tileObject = Instantiate(tilePrefab);

			tileObject.GetComponent<BuildGridTile>().tileData = pair.Value;

			Vector3 tilePosition = new(pair.Key.x + (tileSize / 2), 0, pair.Key.y + (tileSize / 2));

			tileObject.name = "Tile (" + pair.Key.x.ToString() + ", " + pair.Key.y.ToString() + ")";
			tileObject.transform.SetParent(gridContainer);
			tileObject.transform.position = tilePosition;
		}
	}

	private void CreateVertexStore() {
		vertexStore = VertexStore.getInstance;

		for (int z = gridOffsetZ; z < gridOffsetZ + gridSizeZ; z++) {
			for (int x = gridOffsetX; x < gridOffsetX + gridSizeX; x++) {

				Vector2Int coordinate = new Vector2Int(x, z);
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
				Vector2Int B = new Vector2Int(x, z + 1);
				Vector2Int C = new Vector2Int(x, z);
				Vector2Int D = new Vector2Int(x - 1, z);

				Vertex vertexB = vertexStore.GetVertex(B);
				Vertex vertexC = vertexStore.GetVertex(C);
				Vertex vertexD = vertexStore.GetVertex(D);

				AddEdgeToStore(new Vector2Int[] { B, C }, vertexB, vertexC);
				AddEdgeToStore(new Vector2Int[] { D, C }, vertexD, vertexC);
			}
		}
	}

	private void AddEdgeToStore(Vector2Int[] coordinates, Vertex vertexA, Vertex vertexB) {
		if (vertexA != null && vertexB != null) {
			edgeStore.AddEdge(coordinates, vertexA, vertexB);
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
				Vector2Int A = new Vector2Int(x - 1, z + 1);
				Vector2Int B = new Vector2Int(x, z + 1);
				Vector2Int C = new Vector2Int(x, z);
				Vector2Int D = new Vector2Int(x - 1, z);

				Vertex vertexA = vertexStore.GetVertex(A);
				Vertex vertexB = vertexStore.GetVertex(B);
				Vertex vertexC = vertexStore.GetVertex(C);
				Vertex vertexD = vertexStore.GetVertex(D);

				if (vertexA == null || vertexB == null || vertexC == null || vertexD == null) continue;

				Vector2Int[] AB = new Vector2Int[2] { A, B };
				Vector2Int[] BC = new Vector2Int[2] { B, C };
				Vector2Int[] DC = new Vector2Int[2] { D, C };
				Vector2Int[] AD = new Vector2Int[2] { A, D };

				Edge edgeAB = edgeStore.GetEdge(AB);
				Edge edgeBC = edgeStore.GetEdge(BC);
				Edge edgeDC = edgeStore.GetEdge(DC);
				Edge edgeAD = edgeStore.GetEdge(AD);

				if (edgeAB == null || edgeBC == null || edgeDC == null || edgeAD == null) continue;

				Vertex[] vertices = new Vertex[4] { vertexA, vertexB, vertexC, vertexD };
				Edge[] edges = new Edge[4] { edgeAB, edgeBC, edgeDC, edgeAD };

				Vector2Int coordinates = new Vector2Int(x, z);

				tileStore.AddTile(coordinates, vertices, edges);
			}
		}
	}

}
