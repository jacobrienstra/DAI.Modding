namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyFloatProvider : FloatProvider
	{
		[FieldOffset(8, 32)]
		public ExternalObject<DifficultyFloat> Identifier { get; set; }
	}
}
