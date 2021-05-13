using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundGraphVoiceInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<SoundGraphPluginInfo> Plugins { get; set; }

		public SoundGraphVoiceInfo()
		{
			Plugins = new List<SoundGraphPluginInfo>();
		}
	}
}
