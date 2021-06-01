namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AudioGraphAssetParameterConfigData : AudioGraphParameterConfigData
	{
		[FieldOffset(12, 40)]
		public ExternalObject<SoundWaveAsset> Asset { get; set; }
	}
}
