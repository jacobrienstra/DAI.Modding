namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIDataSourceInfo : LinkObject
	{
		[FieldOffset(0, 0)]
		public string DataName { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<UIComponentData> DataCategory { get; set; }

		[FieldOffset(8, 16)]
		public int DataKey { get; set; }

		[FieldOffset(12, 20)]
		public bool UseDirectAccess { get; set; }

		[FieldOffset(13, 21)]
		public bool UpdateOnInitialize { get; set; }
	}
}
