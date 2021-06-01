namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FaceCustomizationAsset : Asset
	{
		[FieldOffset(12, 72)]
		public FaceCustomizationData FaceCustomizationData { get; set; }
	}
}
