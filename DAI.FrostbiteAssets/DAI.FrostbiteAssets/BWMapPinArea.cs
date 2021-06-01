namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWMapPinArea : BWMapPin
	{
		[FieldOffset(64, 192)]
		public ExternalObject<BWMap> Map { get; set; }
	}
}
