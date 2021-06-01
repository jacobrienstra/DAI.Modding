namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PartyMemberAtIndex : CSMEntityProvider
	{
		[FieldOffset(8, 32)]
		public uint Index { get; set; }
	}
}
