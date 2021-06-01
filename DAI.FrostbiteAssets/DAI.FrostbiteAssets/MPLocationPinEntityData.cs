namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class MPLocationPinEntityData : SpatialEntityData
	{
		[FieldOffset(80, 176)]
		public int PinCategory { get; set; }
	}
}
