namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LocalWindForceEntityBaseData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public float Strength { get; set; }

		[FieldOffset(84, 180)]
		public float Variation { get; set; }

		[FieldOffset(88, 184)]
		public float VariationRate { get; set; }

		[FieldOffset(92, 188)]
		public float MicroVariation { get; set; }

		[FieldOffset(96, 192)]
		public float Hardness { get; set; }

		[FieldOffset(100, 196)]
		public float ForceAsInstantVelocity { get; set; }

		[FieldOffset(104, 200)]
		public ExternalObject<ForceGroupAsset> ForceGroup { get; set; }
	}
}
