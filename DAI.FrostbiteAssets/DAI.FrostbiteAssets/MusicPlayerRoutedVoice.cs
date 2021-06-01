using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MusicPlayerRoutedVoice : LinkObject
	{
		[FieldOffset(0, 0)]
		public List<MusicPlayerRoutedPlugins> RoutedPlugins { get; set; }

		[FieldOffset(4, 8)]
		public List<MusicPlayerRoutedTargetPlugins> RoutedTargetPlugins { get; set; }

		[FieldOffset(8, 16)]
		public byte LayerCount { get; set; }

		public MusicPlayerRoutedVoice()
		{
			RoutedPlugins = new List<MusicPlayerRoutedPlugins>();
			RoutedTargetPlugins = new List<MusicPlayerRoutedTargetPlugins>();
		}
	}
}
