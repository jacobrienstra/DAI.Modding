namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class PA2LookAtTarget : DataContainer
	{
		[FieldOffset(8, 24)]
		public ExternalObject<EntityTrackBaseData> EntityTrack { get; set; }
	}
}
