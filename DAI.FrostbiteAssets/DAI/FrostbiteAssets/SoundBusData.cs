namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundBusData : AudioGraphNodeData
	{
		[FieldOffset(8, 48)]
		public string BusName { get; set; }

		[FieldOffset(12, 56)]
		public byte ChannelCount { get; set; }

		[FieldOffset(13, 57)]
		public SoundGraphPluginRef SubmixPlugin { get; set; }
	}
}
