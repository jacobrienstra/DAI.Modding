namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class VisualEnvironmentEffectEntityData : EffectEntityData
	{
		[FieldOffset(128, 240)]
		public Vec4 LifetimeCurve { get; set; }

		[FieldOffset(144, 256)]
		public Vec4 CullAngleCurve { get; set; }

		[FieldOffset(160, 272)]
		public Vec4 CullDistanceCurve { get; set; }

		[FieldOffset(176, 288)]
		public ExternalObject<VisualEnvironmentBlueprint> VisualEnvironment { get; set; }

		[FieldOffset(180, 296)]
		public float Lifetime { get; set; }

		[FieldOffset(184, 300)]
		public bool SampleOnStartOnly { get; set; }

		[FieldOffset(185, 301)]
		public bool HideOccluded { get; set; }
	}
}
