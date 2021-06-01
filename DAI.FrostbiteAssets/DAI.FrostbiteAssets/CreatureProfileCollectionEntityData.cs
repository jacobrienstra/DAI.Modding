namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureProfileCollectionEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<CreatureProfileCollection> Collection { get; set; }

		[FieldOffset(20, 104)]
		public int ActiveIndex { get; set; }
	}
}
