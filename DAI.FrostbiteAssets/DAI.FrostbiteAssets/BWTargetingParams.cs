namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWTargetingParams : LinkObject
	{
		[FieldOffset(0, 0)]
		public float MinDistance { get; set; }

		[FieldOffset(4, 4)]
		public float MaxDistance { get; set; }

		[FieldOffset(8, 8)]
		public ExternalObject<BWVisualEffectEntityData> TargetingVFX { get; set; }
	}
}
