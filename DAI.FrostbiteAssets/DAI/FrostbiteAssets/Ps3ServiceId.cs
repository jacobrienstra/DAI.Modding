namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps3ServiceId : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ServiceIdSpId { get; set; }

		[FieldOffset(4, 8)]
		public string ServiceIdTitleId { get; set; }
	}
}
