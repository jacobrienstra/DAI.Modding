namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TeleportEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public LinearTransform NewPositionTransform { get; set; }
	}
}
