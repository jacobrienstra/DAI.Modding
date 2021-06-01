namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWCSMStateBase : BWActionListContainer
	{
		[FieldOffset(16, 96)]
		public uint CSMHash { get; set; }
	}
}
