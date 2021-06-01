namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWItemStatValuePair : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> Stat { get; set; }

		[FieldOffset(4, 8)]
		public Delegate_float Value { get; set; }
	}
}
