namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementLoadingCardEntityData : UIElementLoadingBitmapEntityData
	{
		[FieldOffset(272, 400)]
		public string ShadowTextureId { get; set; }

		[FieldOffset(276, 408)]
		public float ExtraShadowScale { get; set; }

		[FieldOffset(280, 412)]
		public Vec2 ShadowOffset { get; set; }
	}
}
