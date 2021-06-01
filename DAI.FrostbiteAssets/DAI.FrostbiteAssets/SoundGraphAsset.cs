namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphAsset : SoundAsset
	{
		[FieldOffset(20, 88)]
		public ExternalObject<SoundGraphData> Graph { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<MixerAsset> Mixer { get; set; }
	}
}
