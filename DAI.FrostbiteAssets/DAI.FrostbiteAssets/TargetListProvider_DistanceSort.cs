namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TargetListProvider_DistanceSort : TargetListProvider
	{
		[FieldOffset(8, 24)]
		public ExternalObject<TargetListProvider> Targets { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<TransformProvider> Reference { get; set; }

		[FieldOffset(16, 40)]
		public float YBias { get; set; }

		[FieldOffset(20, 44)]
		public bool FarthestFirst { get; set; }
	}
}
