using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_ForEachNearbyCharacter : BTIteratorFunc
	{
		[FieldOffset(12, 32)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(16, 36)]
		public EForEachNearbyCharacterSortOrder SortOrder { get; set; }

		[FieldOffset(20, 40)]
		public float Radius { get; set; }

		[FieldOffset(24, 44)]
		public float ArcSize { get; set; }

		[FieldOffset(28, 48)]
		public float ArcOffset { get; set; }

		[FieldOffset(32, 52)]
		public int SourceBoneId { get; set; }

		[FieldOffset(36, 56)]
		public bool IncludeHostiles { get; set; }

		[FieldOffset(37, 57)]
		public bool IncludeStealthCharacters { get; set; }

		[FieldOffset(38, 58)]
		public bool IncludeFriendlies { get; set; }

		[FieldOffset(39, 59)]
		public bool UseCharacterOrientationOverride { get; set; }
	}
}
