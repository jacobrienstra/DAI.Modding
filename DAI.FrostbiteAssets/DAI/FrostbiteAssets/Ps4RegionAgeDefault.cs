namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps4RegionAgeDefault : LinkObject
	{
		[FieldOffset(0, 0)]
		public string RegionTitleId { get; set; }

		[FieldOffset(4, 8)]
		public int AgeRequirement { get; set; }
	}
}
