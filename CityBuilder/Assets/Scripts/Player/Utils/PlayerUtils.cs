using UnityEngine;

namespace Player {

	public static class PlayerUtils {

		public static Vector2Int GetVertexCoordinates(Vector2Int[] vertexCoordinates, Vector2 position) {
			Vector2Int closestVertex = Vector2Int.zero;
			float minDistance = float.MaxValue;

			foreach (Vector2Int vertex in vertexCoordinates) {
				float distance = Vector2.Distance(position, vertex);

				if (distance < minDistance) {
					minDistance = distance;
					closestVertex = vertex;
				}
			}

			return closestVertex;
		}

		public static Vector2Int[] GetEdgeCoordinates(Vector2Int[] vertexCoordinates, Vector2 position) {
			Vector2Int firstClosestVertex = Vector2Int.zero, secondClosestVertex = Vector2Int.zero;
			float firstMinDistance = float.MaxValue, secondMinDistance = float.MaxValue;

			foreach (Vector2Int vertex in vertexCoordinates) {
				float distance = Vector2.Distance(position, vertex);

				if (distance < firstMinDistance) {

					secondMinDistance = firstMinDistance;
					secondClosestVertex = firstClosestVertex;
					firstMinDistance = distance;
					firstClosestVertex = vertex;

				} else if (distance < secondMinDistance && distance > firstMinDistance) {

					secondMinDistance = distance;
					secondClosestVertex = vertex;

				}
			}

			return new Vector2Int[2] { firstClosestVertex, secondClosestVertex };
		}

		public static Vector2Int[] GetTileCoordinates(Vector2 position) {
			// going to need to add something here for variable tile size
			Vector2Int A = new(Mathf.FloorToInt(position.x), Mathf.CeilToInt(position.y));
			Vector2Int B = new(Mathf.CeilToInt(position.x), Mathf.CeilToInt(position.y));
			Vector2Int C = new(Mathf.CeilToInt(position.x), Mathf.FloorToInt(position.y));
			Vector2Int D = new(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y));

			return new Vector2Int[4] { A, B, C, D };
		}

	}

}