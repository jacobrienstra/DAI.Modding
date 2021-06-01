namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWMapPinCategoryDescription : DataContainer
	{
		[FieldOffset(8, 24)]
		public int PinCategory { get; set; }

		[FieldOffset(12, 32)]
		public string PinIcon { get; set; }

		[FieldOffset(16, 40)]
		public float DiscoveryRadius { get; set; }

		[FieldOffset(20, 44)]
		public float VisibilityRadius { get; set; }

		[FieldOffset(24, 48)]
		public bool ShowInCompass { get; set; }

		[FieldOffset(25, 49)]
		public bool ShowInMap { get; set; }

		[FieldOffset(26, 50)]
		public bool Discoverable { get; set; }

		[FieldOffset(27, 51)]
		public bool ClampOnRadar { get; set; }

		[FieldOffset(28, 52)]
		public bool ShowVerticalIndicator { get; set; }
	}
}
