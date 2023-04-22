using System.Collections.Generic;
using UnityEngine;

public class EdgeStore {
	private static EdgeStore instance;

	private Dictionary<Vector2Int[], Edge> edges = new Dictionary<Vector2Int[], Edge>(new Vector2IntArrayComparer());

	public static EdgeStore getInstance {
		get {
			if (instance == null) {
				instance = new EdgeStore();
			}
			return instance;
		}
	}

	public void CreateStore(Vector2Int gridOffset, Vector2Int gridSize) {
		for (int y = gridOffset.y; y <= gridOffset.y + gridSize.y; y++) {
			for (int x = gridOffset.x; x <= gridOffset.x + gridSize.x; x++) {
				/*
				 
												A							B
			current vertex -->	*----------
													|         *		
													|					*		Creating AB and AD for
													|					*    each vertex in grid
													| * * * * *
												D             C	

				*/
				Vector2Int A = new(x, y);
				Vector2Int B = new(x + 1, y);
				Vector2Int D = new(x, y - 1);

				Vertex vertexA = VertexStore.getInstance.GetVertex(A);
				Vertex vertexB = VertexStore.getInstance.GetVertex(B);
				Vertex vertexD = VertexStore.getInstance.GetVertex(D);

				if (vertexA != null && vertexB != null) {
					AddEdge(new Vector2Int[] { A, B }, vertexA, vertexB);
				}
				if (vertexA != null && vertexD != null) {
					AddEdge(new Vector2Int[] { A, D }, vertexA, vertexD);
				}
			}
		}
	}

	public void AddEdge(Vector2Int[] coordinates, Vertex vertexA, Vertex vertexB) {
		if (vertexA == null || vertexB == null) return;

		if (edges.ContainsKey(coordinates)) return;

		edges.Add(coordinates, new Edge(vertexA, vertexB));
	}

	public Dictionary<Vector2Int[], Edge> GetEdges() {
		return edges;
	}

	public Edge GetEdge(Vector2Int[] coordinates) {
		if (coordinates.Length != 2) return null;

		Vector2Int[] edgeCoordinates = SetCoordinatesInCorrectOrder(coordinates);

		if (!edges.ContainsKey(edgeCoordinates)) return null;

		return edges[edgeCoordinates];
	}

	private Vector2Int[] SetCoordinatesInCorrectOrder(Vector2Int[] coordinates) {
		Vector2Int[] edgeCoordinates = new Vector2Int[2] { coordinates[0], coordinates[1] };

		if (coordinates[0].x > coordinates[1].x) {
			edgeCoordinates = new Vector2Int[2] { coordinates[1], coordinates[0] };
		}
		if (coordinates[0].y < coordinates[1].y) {
			edgeCoordinates = new Vector2Int[2] { coordinates[1], coordinates[0] };
		}

		return edgeCoordinates;
	}
}
