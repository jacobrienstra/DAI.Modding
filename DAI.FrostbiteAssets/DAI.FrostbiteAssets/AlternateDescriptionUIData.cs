namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class AlternateDescriptionUIData : LinkObject
	{
		[FieldOffset(0, 0)]
		public int RaceID { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference AlternateDescription { get; set; }
	}
}
