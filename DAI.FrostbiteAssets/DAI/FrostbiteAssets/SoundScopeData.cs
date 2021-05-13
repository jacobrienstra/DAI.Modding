namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundScopeData : DataContainer
	{
		[FieldOffset(8, 24)]
		public string Name { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<SoundScopeStrategyData> DefaultStrategy { get; set; }
	}
}
