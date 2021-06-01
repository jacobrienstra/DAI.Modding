namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class MoverComponentSpawnData : ExtraSpawnData
	{
		[FieldOffset(8, 24)]
		public ExternalObject<MoverTune> ReplacementMoverTune { get; set; }

		[FieldOffset(12, 32)]
		public ExternalObject<Dummy> ReplacementRadiusData { get; set; }
	}
}
