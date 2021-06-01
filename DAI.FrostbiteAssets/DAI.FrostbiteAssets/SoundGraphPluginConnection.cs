using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphPluginConnection : LinkObject
	{
		[FieldOffset(0, 0)]
		public SoundGraphPluginConnectionType ConnectionType { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BusNodeData> Bus { get; set; }

		[FieldOffset(8, 16)]
		public List<SoundGraphPluginConnectionParam> Parameters { get; set; }

		[FieldOffset(12, 24)]
		public byte VoiceIndex { get; set; }

		[FieldOffset(13, 25)]
		public byte PluginIndex { get; set; }

		[FieldOffset(14, 26)]
		public byte SignalIndex { get; set; }

		public SoundGraphPluginConnection()
		{
			Parameters = new List<SoundGraphPluginConnectionParam>();
		}
	}
}
