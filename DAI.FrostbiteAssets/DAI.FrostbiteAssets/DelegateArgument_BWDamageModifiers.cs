namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DelegateArgument_BWDamageModifiers : DelegateArgument
	{
		[FieldOffset(12, 40)]
		public ExternalObject<BWDamageModifiers> Value { get; set; }
	}
}
