using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIAudioEventAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<UIAudioEventMapping> AudioEventMappings { get; set; }

		public UIAudioEventAsset()
		{
			AudioEventMappings = new List<UIAudioEventMapping>();
		}
	}
}
