using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class UIElementBitmapEntityExData : UIElementBitmapEntityData
	{
		[FieldOffset(272, 400)]
		public Vec3 ColorRGB { get; set; }

		[FieldOffset(288, 416)]
		public string DynamicTextureId { get; set; }

		[FieldOffset(292, 424)]
		public string UITextureAtlasResourcePath { get; set; }

		[FieldOffset(296, 432)]
		public float ColorAlpha { get; set; }

		[FieldOffset(300, 436)]
		public UIElementBlendType BlendType { get; set; }
	}
}
