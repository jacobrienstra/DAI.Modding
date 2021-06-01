using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIWidgetSoundMappings : UISoundMappingBase
	{
		[FieldOffset(12, 40)]
		public uint WidgetNameHash { get; set; }

		[FieldOffset(16, 48)]
		public List<ExternalObject<SoundMapperScreenNode>> Mappings { get; set; }

		public UIWidgetSoundMappings()
		{
			Mappings = new List<ExternalObject<SoundMapperScreenNode>>();
		}
	}
}
