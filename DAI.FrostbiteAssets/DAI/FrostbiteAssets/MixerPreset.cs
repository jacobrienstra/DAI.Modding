using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MixerPreset : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint NameHash { get; set; }

		[FieldOffset(12, 32)]
		public List<MixerPresetGroupData> Groups { get; set; }

		[FieldOffset(16, 40)]
		public List<MixerPresetNodeData> Nodes { get; set; }

		public MixerPreset()
		{
			Groups = new List<MixerPresetGroupData>();
			Nodes = new List<MixerPresetNodeData>();
		}
	}
}
