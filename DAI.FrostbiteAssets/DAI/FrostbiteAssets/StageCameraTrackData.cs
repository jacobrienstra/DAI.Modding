using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class StageCameraTrackData : CameraTrackData
	{
		[FieldOffset(32, 144)]
		public CameraLayerType CameraLayerType { get; set; }

		[FieldOffset(36, 148)]
		public CameraAttribute CameraAttribute { get; set; }

		[FieldOffset(40, 152)]
		public CameraSubject CameraSubject { get; set; }

		[FieldOffset(44, 160)]
		public ExternalObject<Dummy> Camera { get; set; }

		[FieldOffset(48, 168)]
		public uint CameraId { get; set; }

		[FieldOffset(52, 176)]
		public ExternalObject<ConversationCharacterProxyObjectTrackData> ObjectTrack { get; set; }

		[FieldOffset(56, 184)]
		public ExternalObject<DofTrackData> DofTrack { get; set; }
	}
}
