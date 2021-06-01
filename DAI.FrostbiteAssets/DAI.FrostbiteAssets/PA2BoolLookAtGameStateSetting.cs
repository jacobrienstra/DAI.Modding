namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2BoolLookAtGameStateSetting : PA2LookAtGameStateSetting
	{
		[FieldOffset(28, 72)]
		public bool Value { get; set; }
	}
}
