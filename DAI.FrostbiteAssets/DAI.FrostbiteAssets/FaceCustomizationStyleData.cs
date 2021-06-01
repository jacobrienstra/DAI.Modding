namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationStyleData
	{
		[FieldOffset(0, 0)]
		public uint UsageHash { get; set; }

		[FieldOffset(4, 4)]
		public int Index { get; set; }
	}
}
