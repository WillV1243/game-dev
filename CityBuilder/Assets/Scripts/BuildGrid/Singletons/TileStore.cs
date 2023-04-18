using System.Collections.Generic;
using UnityEngine;

public class TileStore {
	private static TileStore instance;

	private Dictionary<Vector2Int, Tile> tiles = new();

	public static TileStore getInstance {
		get {
			if (instance == null) {
				instance = new TileStore();
			}
			return instance;
		}
	}

	public Dictionary<Vector2Int, Tile> GetTiles() {
		return tiles;
	}

	public void AddTile(Vector2Int coordinates, Vertex[] vertices, Edge[] edges) {
		if (tiles.ContainsKey(coordinates)) return;

		tiles.Add(coordinates, new Tile(vertices, edges));
	}

	public Tile GetTile(Vector2Int coordinates) {
		if (!tiles.ContainsKey(coordinates)) return null;

		return tiles[coordinates];
	}
}
