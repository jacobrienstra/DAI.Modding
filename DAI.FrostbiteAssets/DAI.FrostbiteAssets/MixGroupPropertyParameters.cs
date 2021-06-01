namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixGroupPropertyParameters
	{
		[FieldOffset(0, 0)]
		public uint Property { get; set; }

		[FieldOffset(4, 4)]
		public float MinOffset { get; set; }

		[FieldOffset(8, 8)]
		public float MaxOffset { get; set; }

		[FieldOffset(12, 12)]
		public float DefaultValue { get; set; }

		[FieldOffset(16, 16)]
		public bool EnableOffsetMinMax { get; set; }

		[FieldOffset(17, 17)]
		public bool OverrideDefaultValue { get; set; }
	}
}
