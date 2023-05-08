namespace Player {

	public class BuildingBlueprint {
		public BuildingType Type { get; set; }
		public BuildingRotation? Rotation { get; set; }
		public Tile RootTile { get; set; }

		public BuildingBlueprint(Tile tile, BuildingType type, BuildingRotation? rotation = null) {
			RootTile = tile;
			Type = type;
			Rotation = rotation;
		}
	}

}