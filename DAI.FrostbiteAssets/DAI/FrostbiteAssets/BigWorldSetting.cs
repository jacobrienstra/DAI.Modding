namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BigWorldSetting : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<SoundPatchConfigurationAsset> Sound { get; set; }

		[FieldOffset(12, 32)]
		public int MinDistance { get; set; }

		[FieldOffset(16, 36)]
		public int MaxDistance { get; set; }

		[FieldOffset(20, 40)]
		public float MinDelayTimeInMinutes { get; set; }

		[FieldOffset(24, 44)]
		public float MaxDelayTimeInMinutes { get; set; }
	}
}
