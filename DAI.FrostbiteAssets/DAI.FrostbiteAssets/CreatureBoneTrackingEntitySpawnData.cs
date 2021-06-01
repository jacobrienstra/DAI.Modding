namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CreatureBoneTrackingEntitySpawnData : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<CreatureBoneTrackingData> MovementData { get; set; }
	}
}
