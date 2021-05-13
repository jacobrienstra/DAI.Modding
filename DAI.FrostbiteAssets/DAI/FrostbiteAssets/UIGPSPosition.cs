namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(8)]
	public class UIGPSPosition
	{
		[FieldOffset(0, 0)]
		public double Latitude { get; set; }

		[FieldOffset(8, 8)]
		public double Longitude { get; set; }

		[FieldOffset(16, 16)]
		public double SeaLevelOffset { get; set; }
	}
}
