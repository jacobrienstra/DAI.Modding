namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PreRollData : ProcessorData
	{
		[FieldOffset(16, 64)]
		public float PreRoll { get; set; }

		[FieldOffset(20, 68)]
		public float UpdatesPerSecond { get; set; }
	}
}
