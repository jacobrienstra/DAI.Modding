namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class AmbientLocatorEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public int Environment { get; set; }

		[FieldOffset(84, 180)]
		public int SpatialFeature { get; set; }

		[FieldOffset(88, 184)]
		public int MaxSimultaneous { get; set; }

		[FieldOffset(92, 188)]
		public float SetBackDistance { get; set; }

		[FieldOffset(96, 192)]
		public float AllowedStopDistance { get; set; }
	}
}
