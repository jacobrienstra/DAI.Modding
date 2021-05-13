using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIScreenEventSoundMappings : UISoundMappingBase
	{
		[FieldOffset(12, 40)]
		public uint ScreenNameHash { get; set; }

		[FieldOffset(16, 48)]
		public List<ExternalObject<SoundMapperScreenNode>> Mappings { get; set; }

		public UIScreenEventSoundMappings()
		{
			Mappings = new List<ExternalObject<SoundMapperScreenNode>>();
		}
	}
}
