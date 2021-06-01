namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWModifiableStatValuePair : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWModifiableStat> Stat { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BWTweakableFloatProvider> Value { get; set; }
	}
}
