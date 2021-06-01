namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphPluginConstructParam
	{
		[FieldOffset(0, 0)]
		public float Value { get; set; }

		[FieldOffset(4, 4)]
		public byte Index { get; set; }
	}
}
