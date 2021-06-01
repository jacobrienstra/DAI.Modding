namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWMapPinSearchZone : BWMapPin
	{
		[FieldOffset(64, 192)]
		public float Radius { get; set; }
	}
}
