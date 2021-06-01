namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISimpleDataSource : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<UIComponentData> DataCategory { get; set; }

		[FieldOffset(4, 8)]
		public int DataKey { get; set; }
	}
}
