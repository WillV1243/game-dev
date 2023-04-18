using System.Collections.Generic;
using UnityEngine;

public class Vector2IntArrayComparer : IEqualityComparer<Vector2Int[]> {
	public bool Equals(Vector2Int[] a, Vector2Int[] b) {
		if (a == b) return true;

		if (a == null || b == null) return false;

		if (a.Length != b.Length) return false;

		for (int i = 0; i < a.Length; i++) {
			if (a[i] != b[i]) return false;
		}

		return true;
	}

	public int GetHashCode(Vector2Int[] obj) {
		int hash = 17;

		for (int i = 0; i < obj.Length; i++) {
			hash = hash * 31 + obj[i].GetHashCode();
		}

		return hash;
	}
}