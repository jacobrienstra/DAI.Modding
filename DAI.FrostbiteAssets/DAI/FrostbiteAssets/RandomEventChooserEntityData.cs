namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class RandomEventChooserEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int ChooseCount { get; set; }

		[FieldOffset(20, 100)]
		public bool ExhaustOutputs { get; set; }

		[FieldOffset(21, 101)]
		public bool TrueRandom { get; set; }
	}
}
