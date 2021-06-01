namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationUniversalShapeData
	{
		[FieldOffset(0, 0)]
		public uint UniversalShapeId { get; set; }

		[FieldOffset(4, 4)]
		public uint Value { get; set; }

		[FieldOffset(8, 8)]
		public bool IsTwoWay { get; set; }
	}
}
