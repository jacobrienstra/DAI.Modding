namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphPluginConnectionParam
	{
		[FieldOffset(0, 0)]
		public int Value { get; set; }

		[FieldOffset(4, 4)]
		public byte Index { get; set; }
	}
}
