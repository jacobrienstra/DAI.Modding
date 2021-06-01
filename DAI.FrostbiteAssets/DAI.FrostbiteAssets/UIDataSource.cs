namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIDataSource : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> DataCategory { get; set; }

		[FieldOffset(4, 8)]
		public int DataKey { get; set; }

		[FieldOffset(8, 16)]
		public string SchematicsProperty { get; set; }
	}
}
