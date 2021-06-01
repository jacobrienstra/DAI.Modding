namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BWDepletableStatValuePair : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<BWDepletableStat> Stat { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BWTweakableFloatProvider> Value { get; set; }
	}
}
