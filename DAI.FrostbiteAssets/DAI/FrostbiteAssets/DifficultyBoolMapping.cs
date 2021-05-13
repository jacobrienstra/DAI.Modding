namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class DifficultyBoolMapping : LinkObject
	{
		[FieldOffset(0, 0)]
		public ExternalObject<Dummy> Identifier { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<Dummy> Value { get; set; }
	}
}
