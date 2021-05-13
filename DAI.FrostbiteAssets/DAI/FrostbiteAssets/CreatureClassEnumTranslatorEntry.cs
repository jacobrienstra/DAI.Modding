using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureClassEnumTranslatorEntry
	{
		[FieldOffset(0, 0)]
		public PartyMemberClassType CodeEnum { get; set; }

		[FieldOffset(4, 4)]
		public int ClassID { get; set; }
	}
}
