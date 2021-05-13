namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_DamageType : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public int Value { get; set; }
	}
}
