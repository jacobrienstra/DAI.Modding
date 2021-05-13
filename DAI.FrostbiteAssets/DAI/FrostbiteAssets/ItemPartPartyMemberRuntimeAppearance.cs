namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemPartPartyMemberRuntimeAppearance : LinkObject
	{
		[FieldOffset(0, 0)]
		public ItemBlueprintRuntimeRef AppearanceRuntimeRef { get; set; }

		[FieldOffset(20, 48)]
		public ItemPartyMemberAppearanceIDStruct AppearanceID { get; set; }
	}
}
