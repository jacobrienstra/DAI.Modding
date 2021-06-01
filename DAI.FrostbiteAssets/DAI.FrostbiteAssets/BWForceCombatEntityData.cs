using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWForceCombatEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 108)]
		public bool ApplyToTriggeringCharacter { get; set; }
	}
}
