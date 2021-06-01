namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UpdateNightColorData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public Vec3 NightColor { get; set; }

		[FieldOffset(32, 80)]
		public bool AffectedByEnvironmentScale { get; set; }
	}
}
