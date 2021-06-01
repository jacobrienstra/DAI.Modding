namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyFloat : DifficultyValue
	{
		[FieldOffset(16, 80)]
		public ExternalObject<FloatProvider_Const> DefaultValue { get; set; }
	}
}
