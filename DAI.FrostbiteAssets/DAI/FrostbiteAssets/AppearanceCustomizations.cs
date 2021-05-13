namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AppearanceCustomizations : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<MorphStatic> MorphHead { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<MorphStatic> MorphHeadNoEars { get; set; }

		[FieldOffset(8, 16)]
		public ExternalObject<AppearanceTintSet> Tint { get; set; }
	}
}
