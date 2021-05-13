using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ItemManagerEntity_ClassInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public PartyMemberClassType Id { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference Name { get; set; }
	}
}
