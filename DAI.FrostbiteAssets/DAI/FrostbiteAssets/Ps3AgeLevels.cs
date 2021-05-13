namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps3AgeLevels
	{
		[FieldOffset(0, 0)]
		public int AgeLevel7 { get; set; }

		[FieldOffset(4, 4)]
		public int AgeLevel8 { get; set; }

		[FieldOffset(8, 8)]
		public int AgeLevel9 { get; set; }

		[FieldOffset(12, 12)]
		public int AgeLevel10 { get; set; }
	}
}
