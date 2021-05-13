namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SpatialSoundEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public ExternalObject<SoundAsset> Sound { get; set; }

		[FieldOffset(84, 184)]
		public bool PlayOnCreation { get; set; }
	}
}
