namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MoverFollowLeaderEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public FollowMoverSpec FollowingParameters { get; set; }

		[FieldOffset(28, 108)]
		public uint FlockId { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<Dummy> MovementOverride { get; set; }
	}
}
