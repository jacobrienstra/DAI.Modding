using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GroupTransformLayerData : TransformLayerData
	{
		[FieldOffset(32, 144)]
		public List<ExternalObject<ConversationMasterLinkEntityData>> Children { get; set; }

		public GroupTransformLayerData()
		{
			Children = new List<ExternalObject<ConversationMasterLinkEntityData>>();
		}
	}
}
