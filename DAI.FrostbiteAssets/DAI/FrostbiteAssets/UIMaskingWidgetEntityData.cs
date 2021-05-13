namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIMaskingWidgetEntityData : UIWidgetEntityData
	{
		[FieldOffset(68, 184)]
		public string MaskTextureId { get; set; }

		[FieldOffset(72, 192)]
		public float MaskTextureAlphaThreshold { get; set; }

		[FieldOffset(76, 196)]
		public bool MaskTextureInvertAlphaThreshold { get; set; }

		[FieldOffset(80, 208)]
		public Vec4 BoundsRect { get; set; }

		[FieldOffset(96, 224)]
		public Vec4 MaskTextureUVRect { get; set; }
	}
}
