using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<SoundGraphVoiceInfo> Voices { get; set; }

		[FieldOffset(4, 8)]
		public List<SoundGraphLinkedPluginAttribute> LinkedPluginAttributes { get; set; }

		[FieldOffset(8, 16)]
		public List<SoundGraphPluginConnection> Connections { get; set; }

		[FieldOffset(12, 24)]
		public List<SoundGraphPluginConstructParam> ConstructParams { get; set; }

		[FieldOffset(16, 32)]
		public uint PluginsParamCount { get; set; }

		[FieldOffset(20, 36)]
		public uint PluginCount { get; set; }

		public SoundGraphInfo()
		{
			Voices = new List<SoundGraphVoiceInfo>();
			LinkedPluginAttributes = new List<SoundGraphLinkedPluginAttribute>();
			Connections = new List<SoundGraphPluginConnection>();
			ConstructParams = new List<SoundGraphPluginConstructParam>();
		}
	}
}
