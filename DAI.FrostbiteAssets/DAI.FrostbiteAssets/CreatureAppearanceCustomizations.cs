namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureAppearanceCustomizations : LinkObject
	{
		[FieldOffset(0, 0)]
		public AppearanceCustomizations AppearanceCustomizations { get; set; }

		[FieldOffset(12, 24)]
		public LocalizedStringReference OverrideName { get; set; }

		[FieldOffset(16, 48)]
		public float MinimumScale { get; set; }

		[FieldOffset(20, 52)]
		public float MaximumScale { get; set; }
	}
}
