using System.Collections.Generic;
using UnityEngine;

public class TileStore {
	private static TileStore instance;

	private Dictionary<Vector3, Tile> tiles = new();

	public static TileStore getInstance {
		get {
			if (instance == null) {
				instance = new TileStore();
			}
			return instance;
		}
	}

	public Dictionary<Vector3, Tile> GetTiles() {
		return tiles;
	}

	public void AddTile(Vector3 coordinates, Vertex[] vertices, Edge[] edges) {
		if (tiles.ContainsKey(coordinates)) return;

		tiles.Add(coordinates, new Tile(vertices, edges));
	}

	public Tile GetTile(Vector3 coordinates) {
		if (!tiles.ContainsKey(coordinates)) return null;

		return tiles[coordinates];
	}
}
