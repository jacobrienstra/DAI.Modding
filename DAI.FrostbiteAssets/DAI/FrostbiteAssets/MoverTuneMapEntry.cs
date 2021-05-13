namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MoverTuneMapEntry : LinkObject
	{
		[FieldOffset(0, 0)]
		public MoverTuneId MoverTuneId { get; set; }

		[FieldOffset(4, 8)]
		public ExternalObject<MoverTuneOverride> MoverTune { get; set; }
	}
}
