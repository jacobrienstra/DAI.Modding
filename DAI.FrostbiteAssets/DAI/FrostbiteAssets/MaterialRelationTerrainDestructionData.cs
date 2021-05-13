namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MaterialRelationTerrainDestructionData : PhysicsPropertyRelationPropertyData
	{
		[FieldOffset(8, 40)]
		public float Width { get; set; }

		[FieldOffset(12, 44)]
		public float RelativeWidthDeviation { get; set; }

		[FieldOffset(16, 48)]
		public float Depth { get; set; }

		[FieldOffset(20, 52)]
		public float RelativeDepthDeviation { get; set; }
	}
}
