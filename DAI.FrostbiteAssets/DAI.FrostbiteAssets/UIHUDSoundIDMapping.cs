namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIHUDSoundIDMapping : UISoundMappingBase
	{
		[FieldOffset(12, 40)]
		public int SoundIDValue { get; set; }

		[FieldOffset(16, 48)]
		public ExternalObject<Dummy> SoundEvent { get; set; }

		[FieldOffset(20, 56)]
		public ExternalObject<SoundPatchConfigurationAsset> SoundAction { get; set; }
	}
}
