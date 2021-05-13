namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationUniqueShapeData
	{
		[FieldOffset(0, 0)]
		public uint UsageHash { get; set; }

		[FieldOffset(4, 4)]
		public uint UniqueShapeId { get; set; }

		[FieldOffset(8, 8)]
		public float BlendValue { get; set; }
	}
}
