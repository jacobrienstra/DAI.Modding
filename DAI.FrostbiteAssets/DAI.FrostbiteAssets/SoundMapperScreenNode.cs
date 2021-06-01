using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SoundMapperScreenNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public uint ScreenNameHash { get; set; }

		[FieldOffset(24, 72)]
		public List<ExternalObject<SoundMapperScreenNode>> WidgetOutputs { get; set; }

		[FieldOffset(28, 80)]
		public ExternalObject<UINodePort> EnterScreen { get; set; }

		[FieldOffset(32, 88)]
		public ExternalObject<UINodePort> ExitScreen { get; set; }

		[FieldOffset(36, 96)]
		public List<ExternalObject<SoundMapperScreenNode>> Outputs { get; set; }

		public SoundMapperScreenNode()
		{
			WidgetOutputs = new List<ExternalObject<SoundMapperScreenNode>>();
			Outputs = new List<ExternalObject<SoundMapperScreenNode>>();
		}
	}
}
