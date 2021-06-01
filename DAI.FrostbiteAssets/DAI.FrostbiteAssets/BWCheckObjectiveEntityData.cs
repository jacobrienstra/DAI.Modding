using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCheckObjectiveEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Realm Realm { get; set; }

		[FieldOffset(20, 100)]
		public int ObjectiveToCheck { get; set; }

		[FieldOffset(24, 104)]
		public int Objective { get; set; }
	}
}
