using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class StageTrackableSettingsHeightAdjustment : StageTrackableSettings
	{
		[FieldOffset(12, 32)]
		public string TrackableBoneName { get; set; }

		[FieldOffset(16, 48)]
		public Vec3 TrackableBoneDefaultLocalPosition { get; set; }

		[FieldOffset(32, 64)]
		public uint TrackableBoneHash { get; set; }

		[FieldOffset(36, 68)]
		public TrackableAttachmentType AttachmentType { get; set; }

		[FieldOffset(40, 72)]
		public bool OnlyAdjustHeight { get; set; }
	}
}
