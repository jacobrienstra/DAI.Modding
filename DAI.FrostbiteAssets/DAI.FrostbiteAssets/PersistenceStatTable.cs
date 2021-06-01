namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PersistenceStatTable : DataContainer
	{
		[FieldOffset(8, 24)]
		public string TableName { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<DA3PersistenceData> OwnerPersistenceData { get; set; }
	}
}
