using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_ForEachPerceivedCharacter : BTIteratorFunc
	{
		[FieldOffset(12, 32)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(16, 36)]
		public EForEachNearbyCharacterSortOrder SortOrder { get; set; }

		[FieldOffset(20, 40)]
		public SourcePerceptionList PerceptionList { get; set; }
	}
}
