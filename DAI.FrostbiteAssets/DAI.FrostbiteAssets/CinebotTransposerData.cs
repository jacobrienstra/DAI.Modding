namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotTransposerData : CinebotTrackableData
	{
		[FieldOffset(24, 112)]
		public bool LockTrackble { get; set; }
	}
}
