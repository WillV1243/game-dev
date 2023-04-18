using System.Collections.Generic;
using UnityEngine;

public class VertexStore {
	private static VertexStore instance;

	private Dictionary<Vector2Int, Vertex> vertices = new();

	public static VertexStore getInstance {
		get {
			if (instance == null) {
				instance = new VertexStore();
			}
			return instance;
		}
	}

	public Dictionary<Vector2Int, Vertex> GetVertices() {
		return vertices;
	}

	public void AddVertex(Vector2Int coordinate) {
		if (vertices.ContainsKey(coordinate)) return;

		vertices.Add(coordinate, new Vertex(coordinate));
	}

	public Vertex GetVertex(Vector2Int coordinate) {
		if (!vertices.ContainsKey(coordinate)) return null;

		return vertices[coordinate];
	}
}
