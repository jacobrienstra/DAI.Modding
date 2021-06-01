using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ActionNode : UINodeData
	{
		[FieldOffset(20, 64)]
		public int ActionKey { get; set; }

		[FieldOffset(24, 72)]
		public List<string> Params { get; set; }

		[FieldOffset(28, 80)]
		public ExternalObject<BWPopUpAsset> ActionAsset { get; set; }

		[FieldOffset(32, 88)]
		public ExternalObject<UINodePort> In { get; set; }

		[FieldOffset(36, 96)]
		public List<ExternalObject<Dummy>> DataInputs { get; set; }

		[FieldOffset(40, 104)]
		public ExternalObject<UINodePort> Out { get; set; }

		[FieldOffset(44, 112)]
		public bool AppendIncomingParams { get; set; }

		public ActionNode()
		{
			Params = new List<string>();
			DataInputs = new List<ExternalObject<Dummy>>();
		}
	}
}
