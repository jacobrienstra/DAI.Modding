namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MatchStatItem : LinkObject
	{
		[FieldOffset(0, 0)]
		public string ItemName { get; set; }
	}
}
