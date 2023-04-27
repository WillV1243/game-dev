using System.Collections.Generic;
using UnityEngine;

public class TileStore {
	private static TileStore instance;

	private Dictionary<Vector2Int[], Tile> tiles = new Dictionary<Vector2Int[], Tile>(new Vector2IntArrayComparer());

	public static TileStore getInstance {
		get {
			if (instance == null) {
				instance = new TileStore();
			}
			return instance;
		}
	}

	public void CreateStore(Vector2Int gridOffset, Vector2Int gridSize) {
		for (int y = gridOffset.y; y <= gridOffset.y + gridSize.y; y++) {
			for (int x = gridOffset.x; x <= gridOffset.x + gridSize.x; x++) {
				/*
															AB
												A             B
			current vertex -->	* ------- *
													|         |
										AD    |					|    BC
													|					|
													* ------- *
												D             C	
															DC
				*/
				Vector2Int A = new(x, y);
				Vector2Int B = new(x + 1, y);
				Vector2Int C = new(x + 1, y - 1);
				Vector2Int D = new(x, y - 1);

				Vertex vertexA = VertexStore.getInstance.GetVertex(A);
				Vertex vertexB = VertexStore.getInstance.GetVertex(B);
				Vertex vertexC = VertexStore.getInstance.GetVertex(C);
				Vertex vertexD = VertexStore.getInstance.GetVertex(D);

				if (vertexA == null || vertexB == null || vertexC == null || vertexD == null) continue;

				Vector2Int[] AB = new Vector2Int[2] { A, B };
				Vector2Int[] BC = new Vector2Int[2] { B, C };
				Vector2Int[] DC = new Vector2Int[2] { D, C };
				Vector2Int[] AD = new Vector2Int[2] { A, D };

				Edge edgeAB = EdgeStore.getInstance.GetEdge(AB);
				Edge edgeBC = EdgeStore.getInstance.GetEdge(BC);
				Edge edgeDC = EdgeStore.getInstance.GetEdge(DC);
				Edge edgeAD = EdgeStore.getInstance.GetEdge(AD);

				if (edgeAB == null || edgeBC == null || edgeDC == null || edgeAD == null) continue;

				Vertex[] vertices = new Vertex[4] { vertexA, vertexB, vertexC, vertexD };
				Edge[] edges = new Edge[4] { edgeAB, edgeBC, edgeDC, edgeAD };

				Vector2Int[] gridKey = new Vector2Int[4] { A, B, C, D };

				AddTile(gridKey, vertices, edges);
			}
		}
	}

	public Dictionary<Vector2Int[], Tile> GetTiles() {
		return tiles;
	}

	public void AddTile(Vector2Int[] coordinates, Vertex[] vertices, Edge[] edges) {
		if (tiles.ContainsKey(coordinates)) return;

		tiles.Add(coordinates, new Tile(vertices, edges));
	}

	public Tile GetTile(Vector2Int[] coordinates) {
		if (coordinates.Length != 4) return null;

		if (!tiles.ContainsKey(coordinates)) return null;

		return tiles[coordinates];
	}

	public Dictionary<Vector2Int[], Tile> GetTileNeighbours(Tile rootTile, Vector2Int buildingSize) {
		Vector2Int startingVertex = rootTile.vertexA.GetCoordinates();
		Dictionary<Vector2Int[], Tile> tiles = new Dictionary<Vector2Int[], Tile>(new Vector2IntArrayComparer());

		for (int y = startingVertex.y; y < startingVertex.y + buildingSize.y; y++) {
			for (int x = startingVertex.x; x < startingVertex.x + buildingSize.x; x++) {

				Vector2Int A = new(x, y);
				Vector2Int B = new(x + 1, y);
				Vector2Int C = new(x + 1, y - 1);
				Vector2Int D = new(x, y - 1);

				Vector2Int[] coordinates = new Vector2Int[4] { A, B, C, D };

				Tile tile = GetTile(coordinates);

				tiles.Add(coordinates, tile);

			}
		}

		return tiles;
	}

	public Dictionary<Vector2Int[], Tile> GetTilesWithBuildingRef(Tile rootTile, GameObject buildingRef) {
		Vector2Int startingVertex = rootTile.vertexA.GetCoordinates();
		Dictionary<Vector2Int[], Tile> tiles = new Dictionary<Vector2Int[], Tile>(new Vector2IntArrayComparer());

		for (int y = startingVertex.y - 5; y < startingVertex.y + 5; y++) {
			for (int x = startingVertex.x - 5; x < startingVertex.x + 5; x++) {

				Vector2Int A = new(x, y);
				Vector2Int B = new(x + 1, y);
				Vector2Int C = new(x + 1, y - 1);
				Vector2Int D = new(x, y - 1);

				Vector2Int[] coordinates = new Vector2Int[4] { A, B, C, D };

				Tile tile = GetTile(coordinates);

				if (tile.buildingRef == buildingRef) tiles.Add(coordinates, tile);

			}
		}

		return tiles;
	}
}
