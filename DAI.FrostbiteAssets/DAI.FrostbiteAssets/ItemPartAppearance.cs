using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemPartAppearance : Asset
	{
		[FieldOffset(12, 72)]
		public ExternalObject<ItemPartType> PartType { get; set; }

		[FieldOffset(16, 80)]
		public List<ItemPartPartyMemberRuntimeAppearance> OverridesRuntime { get; set; }

		[FieldOffset(20, 88)]
		public ItemBlueprintRuntimeRef DefaultRuntimeRef { get; set; }

		public ItemPartAppearance()
		{
			OverridesRuntime = new List<ItemPartPartyMemberRuntimeAppearance>();
		}
	}
}
