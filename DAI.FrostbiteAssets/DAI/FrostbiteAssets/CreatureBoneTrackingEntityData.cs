namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureBoneTrackingEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<CreatureBoneTrackingData> MovementData { get; set; }
	}
}
