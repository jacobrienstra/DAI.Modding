namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SpatialAmbientAction : AmbientAction
	{
		[FieldOffset(52, 168)]
		public ExternalObject<CSMStateReference> MovementState { get; set; }

		[FieldOffset(56, 176)]
		public int SpatialFeature { get; set; }

		[FieldOffset(60, 184)]
		public ExternalObject<MoverTuneOverride> MoverTuneOverride { get; set; }
	}
}
