namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class PointLightEntityData : OriginalLocalLightEntityData
	{
		[FieldOffset(176, 272)]
		public float Width { get; set; }

		[FieldOffset(180, 276)]
		public float TranslucencyAmbient { get; set; }

		[FieldOffset(184, 280)]
		public float TranslucencyScale { get; set; }

		[FieldOffset(188, 284)]
		public float TranslucencyPower { get; set; }

		[FieldOffset(192, 288)]
		public float TranslucencyDistortion { get; set; }
	}
}
