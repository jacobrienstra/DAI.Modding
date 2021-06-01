namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(1)]
	public class SoundGraphPluginRef
	{
		[FieldOffset(0, 0)]
		public bool IsValid { get; set; }

		[FieldOffset(1, 1)]
		public byte VoiceIndex { get; set; }

		[FieldOffset(2, 2)]
		public byte PluginIndex { get; set; }
	}
}
