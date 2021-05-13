namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UISetValueData : EntityData
	{
		[FieldOffset(16, 96)]
		public UISimpleDataSource DataSource { get; set; }

		[FieldOffset(24, 112)]
		public int IntValue { get; set; }

		[FieldOffset(28, 116)]
		public float FloatValue { get; set; }

		[FieldOffset(32, 120)]
		public string StringValue { get; set; }

		[FieldOffset(36, 128)]
		public bool BoolValue { get; set; }
	}
}
