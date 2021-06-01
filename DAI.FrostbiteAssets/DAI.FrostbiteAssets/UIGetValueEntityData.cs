namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIGetValueEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public UISimpleDataSource DataSource { get; set; }

		[FieldOffset(24, 112)]
		public bool AssertOnWrongOutput { get; set; }
	}
}
