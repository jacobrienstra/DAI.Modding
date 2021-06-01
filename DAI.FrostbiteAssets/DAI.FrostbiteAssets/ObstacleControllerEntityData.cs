namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class ObstacleControllerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public ExternalObject<DA3ObstacleDat> ObstacleData { get; set; }

		[FieldOffset(20, 104)]
		public bool ActiveAtStart { get; set; }
	}
}
