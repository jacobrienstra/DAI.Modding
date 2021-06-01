namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMAction_PlaySound : BWCSMAction_PlaySoundBase
	{
		[FieldOffset(44, 96)]
		public ExternalObject<SoundAsset> Asset { get; set; }

		[FieldOffset(48, 104)]
		public ExternalObject<AudioGraphEvent> SoundEvent { get; set; }
	}
}
