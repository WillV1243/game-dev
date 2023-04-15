using System.Collections.Generic;

public class EdgeStore {
	private static EdgeStore instance;

	private Dictionary<Vertex[], Edge> edges = new();

	public static EdgeStore getInstance {
		get {
			if (instance == null) {
				instance = new EdgeStore();
			}
			return instance;
		}
	}

	public Dictionary<Vertex[], Edge> GetEdges() {
		return edges;
	}

	public void AddEdge(Vertex[] vertices) {
		if (vertices.Length != 2) return;

		if (edges.ContainsKey(vertices)) return;

		edges.Add(vertices, new Edge(vertices[0], vertices[1]));
	}

	public Edge GetEdge(Vertex[] vertices) {
		if (vertices.Length != 2) return null;

		if (!edges.ContainsKey(vertices)) return null;

		return edges[vertices];
	}
}
