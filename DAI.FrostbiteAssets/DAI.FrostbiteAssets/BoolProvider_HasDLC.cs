namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_HasDLC : BoolProvider
	{
		[FieldOffset(8, 32)]
		public int DLCPackage { get; set; }
	}
}
