namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWMapPinPortal : BWMapPin
	{
		[FieldOffset(64, 192)]
		public ExternalObject<BWMap> TargetMap { get; set; }
	}
}
