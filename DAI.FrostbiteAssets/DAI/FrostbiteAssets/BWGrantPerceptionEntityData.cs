using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWGrantPerceptionEntityData : ActionIteratorEntityBaseData
	{
		[FieldOffset(20, 104)]
		public Realm Realm { get; set; }

		[FieldOffset(24, 112)]
		public ExternalObject<Dummy> ToBePerceivedList { get; set; }

		[FieldOffset(28, 120)]
		public bool PerceiveAllPartyMembers { get; set; }
	}
}
