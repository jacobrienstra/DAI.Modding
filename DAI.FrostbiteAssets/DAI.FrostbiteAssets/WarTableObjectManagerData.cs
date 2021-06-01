namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class WarTableObjectManagerData : EntityData
	{
		[FieldOffset(16, 96)]
		public float TableViewTriggerDistance { get; set; }

		[FieldOffset(20, 100)]
		public float MapViewTriggerDistance { get; set; }

		[FieldOffset(24, 104)]
		public float TableViewNavigationLowRamp { get; set; }

		[FieldOffset(28, 108)]
		public float TableViewNavigationHighRamp { get; set; }

		[FieldOffset(32, 112)]
		public float MapViewNavigationLowRamp { get; set; }

		[FieldOffset(36, 116)]
		public float MapViewNavigationHighRamp { get; set; }
	}
}
