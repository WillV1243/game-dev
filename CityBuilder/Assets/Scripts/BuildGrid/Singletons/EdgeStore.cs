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

	public Dictionary<Vector2Int[], Edge> GetEdges() {
		return edges;
	}

	public void AddEdge(Vector2Int[] coordinates, Vertex vertexA, Vertex vertexB) {
		if (vertexA == null || vertexB == null) return;

		if (edges.ContainsKey(coordinates)) return;

		edges.Add(coordinates, new Edge(vertexA, vertexB));
	}

	public Edge GetEdge(Vector2Int[] coordinates) {
		if (coordinates.Length != 2) return null;

		if (!edges.ContainsKey(coordinates)) return null;

		return edges[coordinates];
	}
}
