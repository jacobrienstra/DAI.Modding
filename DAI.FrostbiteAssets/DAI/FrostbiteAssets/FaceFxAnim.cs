namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class FaceFxAnim : LinkObject
	{
		[FieldOffset(0, 0)]
		public long RawData { get; set; }

		[FieldOffset(8, 8)]
		public uint AnimId { get; set; }
	}
}
