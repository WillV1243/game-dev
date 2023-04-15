using System.Collections.Generic;
using UnityEngine;

public class VertexStore {
	private static VertexStore instance;

	private Dictionary<Vector3, Vertex> vertices = new();

	public static VertexStore getInstance {
		get {
			if (instance == null) {
				instance = new VertexStore();
			}
			return instance;
		}
	}

	public Dictionary<Vector3, Vertex> GetVertices() {
		return vertices;
	}

	public void AddVertex(Vector3 coordinate) {
		if (vertices.ContainsKey(coordinate)) return;

		vertices.Add(coordinate, new Vertex(coordinate));
	}

	public Vertex GetVertex(Vector3 coordinate) {
		if (!vertices.ContainsKey(coordinate)) return null;

		return vertices[coordinate];
	}
}
