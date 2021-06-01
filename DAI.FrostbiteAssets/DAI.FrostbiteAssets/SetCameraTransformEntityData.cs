namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SetCameraTransformEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public bool DisableInGameView { get; set; }
	}
}
