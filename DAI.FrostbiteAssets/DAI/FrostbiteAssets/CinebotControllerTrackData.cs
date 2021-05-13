namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotControllerTrackData : CinebotTrackableTrackData
	{
		[FieldOffset(32, 144)]
		public ExternalObject<NoiseControllerData> ControllerData { get; set; }
	}
}
