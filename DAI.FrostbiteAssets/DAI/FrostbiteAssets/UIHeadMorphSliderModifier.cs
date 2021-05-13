namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphSliderModifier : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint SliderId { get; set; }

		[FieldOffset(12, 28)]
		public float Weight { get; set; }

		[FieldOffset(16, 32)]
		public ExternalObject<Dummy> WeightCurve { get; set; }

		[FieldOffset(20, 40)]
		public bool IsTwoWay { get; set; }
	}
}
