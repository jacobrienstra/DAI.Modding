namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class LightEffectEntityData : EffectEntityData
	{
		[FieldOffset(128, 240)]
		public Vec4 IntensityCurve { get; set; }

		[FieldOffset(144, 256)]
		public ExternalObject<OriginalLocalLightEntityData> Light { get; set; }

		[FieldOffset(148, 264)]
		public float Lifetime { get; set; }

		[FieldOffset(152, 268)]
		public QualityScalableFloat SpawnProbability { get; set; }

		[FieldOffset(168, 284)]
		public float RandomIntensityMin { get; set; }

		[FieldOffset(172, 288)]
		public float RandomIntensityMax { get; set; }

		[FieldOffset(176, 292)]
		public float IntensityMin { get; set; }

		[FieldOffset(180, 296)]
		public float IntensityMax { get; set; }

		[FieldOffset(184, 300)]
		public bool Looping { get; set; }

		[FieldOffset(185, 301)]
		public bool LocalPlayerOnly { get; set; }
	}
}
