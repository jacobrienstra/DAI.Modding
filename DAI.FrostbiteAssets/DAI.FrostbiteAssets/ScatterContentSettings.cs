namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ScatterContentSettings : LinkObject
	{
		[FieldOffset(0, 0)]
		public int Category { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<ScatterContentTuningOverride> TuningOverride { get; set; }

		[FieldOffset(8, 16)]
		public bool ShouldPersist { get; set; }
	}
}
