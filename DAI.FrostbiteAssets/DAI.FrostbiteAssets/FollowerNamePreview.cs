namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class FollowerNamePreview : LinkObject
	{
		[FieldOffset(0, 0)]
		public int PartyMemberID { get; set; }

		[FieldOffset(4, 8)]
		public LocalizedStringReference NameStringID { get; set; }
	}
}
