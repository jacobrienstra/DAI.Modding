namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ToolTipEntry : DataContainer
	{
		[FieldOffset(8, 24)]
		public uint StringTagHash { get; set; }

		[FieldOffset(12, 32)]
		public LocalizedStringReference StringToDisplay { get; set; }
	}
}
