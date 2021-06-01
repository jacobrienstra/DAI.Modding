namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RetrieveStoredEntity : CSMEntityProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<Dummy> SourceEntity { get; set; }

		[FieldOffset(12, 40)]
		public int Slot { get; set; }
	}
}
