namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotRigTrackData : CinebotHeirarchicalTrackData
	{
		[FieldOffset(28, 136)]
		public ExternalObject<CinebotControllerRigAsset> RigData { get; set; }
	}
}
