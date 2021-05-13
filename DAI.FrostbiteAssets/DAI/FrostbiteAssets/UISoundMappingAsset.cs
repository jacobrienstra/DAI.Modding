using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISoundMappingAsset : UIGraphAsset
	{
		[FieldOffset(48, 144)]
		public ExternalObject<SoundPatchAsset> SoundPatch { get; set; }

		[FieldOffset(52, 152)]
		public List<ExternalObject<Dummy>> HUDWidgets { get; set; }

		[FieldOffset(56, 160)]
		public List<ExternalObject<SoundMapperScreenNode>> HUDSoundIDMappings { get; set; }

		[FieldOffset(60, 168)]
		public List<ExternalObject<SoundMapperScreenNode>> Widgets { get; set; }

		[FieldOffset(64, 176)]
		public List<ExternalObject<SoundMapperScreenNode>> Screens { get; set; }

		public UISoundMappingAsset()
		{
			HUDWidgets = new List<ExternalObject<Dummy>>();
			HUDSoundIDMappings = new List<ExternalObject<SoundMapperScreenNode>>();
			Widgets = new List<ExternalObject<SoundMapperScreenNode>>();
			Screens = new List<ExternalObject<SoundMapperScreenNode>>();
		}
	}
}
