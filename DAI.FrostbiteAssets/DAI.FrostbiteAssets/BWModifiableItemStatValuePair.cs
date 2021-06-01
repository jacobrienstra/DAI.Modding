namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWModifiableItemStatValuePair : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWModifiableStat> Stat { get; set; }

		[FieldOffset(4, 8)]
		public Delegate_float Value { get; set; }
	}
}
