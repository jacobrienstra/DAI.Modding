namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class WaterEntityData : GamePhysicsEntityData
	{
		[FieldOffset(128, 240)]
		public ExternalObject<WaterAsset> Asset { get; set; }
	}
}
