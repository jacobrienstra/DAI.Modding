using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinematicOverTheShoulderControllerData : CinematicHeightAdjustmentControllerData
	{
		[FieldOffset(36, 136)]
		public string DefaultCameraTrackableName { get; set; }

		[FieldOffset(40, 144)]
		public string PivotTrackableName { get; set; }

		[FieldOffset(44, 152)]
		public string PivotTrackableBoneName { get; set; }

		[FieldOffset(48, 160)]
		public uint PivotTrackableBoneHash { get; set; }

		[FieldOffset(52, 164)]
		public float PivotRotationRatio { get; set; }

		[FieldOffset(56, 168)]
		public float PivotMaximumRotation { get; set; }

		[FieldOffset(60, 172)]
		public TrackableAttachmentType AttachmentType { get; set; }
	}
}
