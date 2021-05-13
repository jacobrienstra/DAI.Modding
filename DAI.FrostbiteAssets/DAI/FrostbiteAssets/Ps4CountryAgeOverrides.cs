namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class Ps4CountryAgeOverrides : LinkObject
	{
		[FieldOffset(0, 0)]
		public string CountryCode { get; set; }

		[FieldOffset(4, 8)]
		public int AgeRequirement { get; set; }
	}
}
