namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIPlayerIndicatorCompData : UI3dIconCompData
	{
		[FieldOffset(164, 272)]
		public float DeathVerticalOffset { get; set; }

		[FieldOffset(168, 280)]
		public UITextureAtlasTextureReference PlayerOnePortrait { get; set; }

		[FieldOffset(188, 320)]
		public UITextureAtlasTextureReference PlayerTwoPortrait { get; set; }

		[FieldOffset(208, 360)]
		public UITextureAtlasTextureReference PlayerThreePortrait { get; set; }

		[FieldOffset(228, 400)]
		public UITextureAtlasTextureReference PlayerFourPortrait { get; set; }
	}
}
