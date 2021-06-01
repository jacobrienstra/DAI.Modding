namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BlueprintBundle : SharedBundleBaseAsset
	{
		[FieldOffset(12, 152)]
		public ExternalObject<Blueprint> Blueprint { get; set; }
	}
}
