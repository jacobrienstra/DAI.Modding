namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWAbilityTagRef : LinkObject
	{
		[FieldOffset(0, 0)]
		public uint TagHash { get; set; }
	}
}
