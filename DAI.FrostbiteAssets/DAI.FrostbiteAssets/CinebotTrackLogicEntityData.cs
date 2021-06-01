namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotTrackLogicEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public int TrackIndex { get; set; }

		[FieldOffset(20, 100)]
		public bool IgnoreUnspawnedTrackables { get; set; }

		[FieldOffset(21, 101)]
		public bool TrackLocalPlayer { get; set; }
	}
}
