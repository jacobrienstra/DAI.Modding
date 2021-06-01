using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWSetObjectiveEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 108)]
		public int Objective { get; set; }

		[FieldOffset(28, 112)]
		public bool SetObjectiveOnTriggeringCharacter { get; set; }
	}
}
