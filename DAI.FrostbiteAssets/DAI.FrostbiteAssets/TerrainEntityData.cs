namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TerrainEntityData : GamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public long DecalsResource { get; set; }

		[FieldOffset(136, 248)]
		public ExternalObject<TerrainData> TerrainAsset { get; set; }

		[FieldOffset(140, 256)]
		public MaterialDecl WaterMaterial { get; set; }

		[FieldOffset(144, 272)]
		public bool Visible { get; set; }
	}
}
