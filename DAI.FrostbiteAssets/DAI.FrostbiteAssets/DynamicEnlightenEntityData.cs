namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DynamicEnlightenEntityData : EnlightenEntityData
	{
		[FieldOffset(28, 112)]
		public ExternalObject<EnlightenDataAsset> EnlightenData { get; set; }
	}
}
