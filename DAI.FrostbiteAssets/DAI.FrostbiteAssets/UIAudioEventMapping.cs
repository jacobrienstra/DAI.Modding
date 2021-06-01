namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAudioEventMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public string EventName { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> SoundAsset { get; set; }
	}
}
