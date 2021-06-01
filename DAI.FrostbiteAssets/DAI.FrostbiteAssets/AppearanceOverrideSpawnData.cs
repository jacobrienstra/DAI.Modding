namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AppearanceOverrideSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public CreatureAppearanceCustomizations AppearanceOverride { get; set; }
	}
}
