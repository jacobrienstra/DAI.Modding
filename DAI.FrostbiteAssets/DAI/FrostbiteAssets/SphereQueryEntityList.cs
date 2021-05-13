using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SphereQueryEntityList : TargetListProvider
	{
		[FieldOffset(8, 24)]
		public ESphereQuerySortOrder SortOrder { get; set; }

		[FieldOffset(12, 28)]
		public float Radius { get; set; }

		[FieldOffset(16, 32)]
		public float ArcSize { get; set; }

		[FieldOffset(20, 36)]
		public float ArcOffset { get; set; }

		[FieldOffset(24, 40)]
		public int UseablePropType { get; set; }

		[FieldOffset(28, 48)]
		public ExternalObject<TransformProvider_Self> SourcePosition { get; set; }

		[FieldOffset(32, 56)]
		public ExternalObject<EntityProvider_Self> SelfEntity { get; set; }

		[FieldOffset(36, 64)]
		public bool IncludeHostiles { get; set; }

		[FieldOffset(37, 65)]
		public bool IncludeStealthCharacters { get; set; }

		[FieldOffset(38, 66)]
		public bool IncludeFriendlies { get; set; }
	}
}
