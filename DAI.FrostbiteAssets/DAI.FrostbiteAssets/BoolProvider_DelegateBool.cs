namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BoolProvider_DelegateBool : BWConditional
	{
		[FieldOffset(8, 32)]
		public Delegate_bool BooleanDelegate { get; set; }
	}
}
