using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicPlayerRoutedPlugins : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<SoundGraphPluginRef> Route { get; set; }

		[FieldOffset(4, 8)]
		public SoundGraphPluginRef SndPlayer { get; set; }

		[FieldOffset(7, 11)]
		public SoundGraphPluginRef Rechannel { get; set; }

		[FieldOffset(10, 14)]
		public SoundGraphPluginRef Resample { get; set; }

		[FieldOffset(13, 17)]
		public SoundGraphPluginRef Pause { get; set; }

		[FieldOffset(16, 20)]
		public SoundGraphPluginRef Gain { get; set; }

		public MusicPlayerRoutedPlugins()
		{
			Route = new List<SoundGraphPluginRef>();
		}
	}
}
