namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundDataReference : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<DataContainer> DataOwner { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<SoundWaveAsset> SoundData { get; set; }
	}
}
