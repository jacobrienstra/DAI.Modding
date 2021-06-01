namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyFloatMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<DifficultyFloat> Identifier { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<BWTweakableFloatProvider> Value { get; set; }
	}
}
