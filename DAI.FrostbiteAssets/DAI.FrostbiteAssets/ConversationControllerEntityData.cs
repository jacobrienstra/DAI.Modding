using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ConversationControllerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public List<ExternalObject<Dummy>> Conditions { get; set; }

		[FieldOffset(20, 104)]
		public bool AutoUpdate { get; set; }

		[FieldOffset(21, 105)]
		public QualityScalableBool NeverStreamInEarly { get; set; }

		public ConversationControllerEntityData()
		{
			Conditions = new List<ExternalObject<Dummy>>();
		}
	}
}
