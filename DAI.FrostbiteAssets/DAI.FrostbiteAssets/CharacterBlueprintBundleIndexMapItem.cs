namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CharacterBlueprintBundleIndexMapItem
	{
		[FieldOffset(0, 0)]
		public int ClassID { get; set; }

		[FieldOffset(4, 4)]
		public int GenderID { get; set; }

		[FieldOffset(8, 8)]
		public int RaceID { get; set; }

		[FieldOffset(12, 12)]
		public int BundleIndex { get; set; }
	}
}
