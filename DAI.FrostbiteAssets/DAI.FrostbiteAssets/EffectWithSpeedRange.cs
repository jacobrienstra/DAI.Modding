namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EffectWithSpeedRange : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<EffectBlueprint> Effect { get; set; }

		[FieldOffset(4, 8)]
		public float MinSpeed { get; set; }

		[FieldOffset(8, 12)]
		public float MaxSpeed { get; set; }

		[FieldOffset(12, 16)]
		public byte AttachMaterialIndex { get; set; }

		[FieldOffset(13, 17)]
		public bool AttachToWaterSurface { get; set; }
	}
}
