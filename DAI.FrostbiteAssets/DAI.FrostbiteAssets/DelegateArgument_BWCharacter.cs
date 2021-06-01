namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BWCharacter : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public BWCharacter Value { get; set; }
	}
}
