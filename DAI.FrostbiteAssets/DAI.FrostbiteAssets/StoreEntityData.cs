namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StoreEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<StoreData> Properties { get; set; }
	}
}
