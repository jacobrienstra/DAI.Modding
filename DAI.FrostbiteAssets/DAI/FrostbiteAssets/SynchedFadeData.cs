using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SynchedFadeData : MusicFadeData
	{
		[FieldOffset(28, 48)]
		public MusicSyncType SyncType { get; set; }
	}
}
