namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWRange : DataContainer
	{
		[FieldOffset(8, 24)]
		public float Distance { get; set; }
	}
}
