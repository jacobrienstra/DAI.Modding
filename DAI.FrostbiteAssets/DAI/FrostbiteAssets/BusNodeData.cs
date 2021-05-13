namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BusNodeData : SoundBusData
	{
		[FieldOffset(16, 64)]
		public AudioGraphNodePort Out { get; set; }

		[FieldOffset(24, 96)]
		public SoundGraphPluginRef VuPlugin { get; set; }
	}
}
