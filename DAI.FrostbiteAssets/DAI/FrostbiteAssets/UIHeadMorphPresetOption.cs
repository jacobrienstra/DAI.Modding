namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHeadMorphPresetOption : UIHeadMorphSliderPreset
	{
		[FieldOffset(32, 80)]
		public ExternalObject<FaceCustomizationAsset> FaceCode { get; set; }

		[FieldOffset(36, 88)]
		public byte Index { get; set; }
	}
}
