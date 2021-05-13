namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class DayNightPointLightEntityData : PointLightEntityData
	{
		[FieldOffset(208, 304)]
		public Vec3 NightColor { get; set; }

		[FieldOffset(224, 320)]
		public bool ColorAffectedByEnvironmentScale { get; set; }

		[FieldOffset(225, 321)]
		public bool NightColorAffectedByEnvironmentScale { get; set; }
	}
}
