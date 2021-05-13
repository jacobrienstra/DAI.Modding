using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_HasCharactersNearby : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public TacticsTarget Target { get; set; }

		[FieldOffset(20, 48)]
		public ExternalObject<TransformProvider> OverrideTransform { get; set; }

		[FieldOffset(24, 56)]
		public ExternalObject<Dummy> OverrideRadius { get; set; }

		[FieldOffset(28, 64)]
		public int CharacterCount { get; set; }

		[FieldOffset(32, 68)]
		public BWComparisonType CountComparison { get; set; }

		[FieldOffset(36, 72)]
		public float Radius { get; set; }

		[FieldOffset(40, 76)]
		public float ArcSize { get; set; }

		[FieldOffset(44, 80)]
		public float ArcOffset { get; set; }

		[FieldOffset(48, 84)]
		public int SourceBoneId { get; set; }

		[FieldOffset(52, 88)]
		public bool IncludeHostiles { get; set; }

		[FieldOffset(53, 89)]
		public bool IncludeStealthCharacters { get; set; }

		[FieldOffset(54, 90)]
		public bool IncludeFriendlies { get; set; }

		[FieldOffset(55, 91)]
		public bool UseCharacterOrientationOverride { get; set; }
	}
}
