namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SoundEffectEntityData : EffectEntityData
	{
		[FieldOffset(128, 240)]
		public ExternalObject<SoundAsset> Sound { get; set; }

		[FieldOffset(132, 248)]
		public bool UseDefaultStopEvent { get; set; }
	}
}
