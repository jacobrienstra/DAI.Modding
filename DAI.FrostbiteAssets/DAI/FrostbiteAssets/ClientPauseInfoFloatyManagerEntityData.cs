namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class ClientPauseInfoFloatyManagerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public Vec3 PositionFloatyOffset { get; set; }
	}
}
