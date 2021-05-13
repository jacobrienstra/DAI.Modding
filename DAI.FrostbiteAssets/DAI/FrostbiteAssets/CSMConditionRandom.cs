namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CSMConditionRandom : BWConditional
	{
		[FieldOffset(8, 32)]
		public ExternalObject<FloatProvider> RandomChance { get; set; }

		[FieldOffset(12, 40)]
		public int RandomSeed { get; set; }
	}
}
