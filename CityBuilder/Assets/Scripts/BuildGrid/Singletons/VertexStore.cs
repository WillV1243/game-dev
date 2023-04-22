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

	public void CreateStore(Vector2Int gridOffset, Vector2Int gridSize) {
		for (int y = gridOffset.y; y <= gridOffset.y + gridSize.y; y++) {
			for (int x = gridOffset.x; x <= gridOffset.x + gridSize.x; x++) {

				Vector2Int coordinate = new Vector2Int(x, y);
				AddVertex(coordinate);

			}
		}
	}

	public void AddVertex(Vector2Int coordinate) {
		if (vertices.ContainsKey(coordinate)) return;

		vertices.Add(coordinate, new Vertex(coordinate));
	}

	public Dictionary<Vector2Int, Vertex> GetVertices() {
		return vertices;
	}

	public Vertex GetVertex(Vector2Int coordinate) {
		if (!vertices.ContainsKey(coordinate)) return null;

		return vertices[coordinate];
	}
}
