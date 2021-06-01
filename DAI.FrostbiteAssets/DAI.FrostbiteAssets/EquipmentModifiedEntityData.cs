namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class EquipmentModifiedEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<EquipItemAsset> Item { get; set; }

		[FieldOffset(20, 104)]
		public int FollowerId { get; set; }
	}
}
