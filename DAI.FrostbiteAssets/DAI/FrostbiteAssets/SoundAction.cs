namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundAction : DataContainer
	{
		[FieldOffset(8, 24)]
		public int Action { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<SoundPatchConfigurationAsset> Asset { get; set; }
	}
}
