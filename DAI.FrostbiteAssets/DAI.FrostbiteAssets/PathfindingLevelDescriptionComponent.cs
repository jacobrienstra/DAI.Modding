namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PathfindingLevelDescriptionComponent : LevelDescriptionComponent
	{
		[FieldOffset(8, 24)]
		public float LoadingRadius { get; set; }

		[FieldOffset(12, 28)]
		public float UrgentLoadingRadius { get; set; }

		[FieldOffset(16, 32)]
		public float UnloadingTimeout { get; set; }
	}
}
