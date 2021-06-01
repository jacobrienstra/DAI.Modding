namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class TorusTransposerRotation : DataContainer
	{
		[FieldOffset(8, 24)]
		public string TargetOverride { get; set; }

		[FieldOffset(12, 32)]
		public string TargetOverridePart { get; set; }
	}
}
