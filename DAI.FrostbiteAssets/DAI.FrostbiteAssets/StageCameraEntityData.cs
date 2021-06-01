using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class StageCameraEntityData : StageObjectEntityData
	{
		[FieldOffset(96, 192)]
		public HdrParameters HdrParameters { get; set; }

		[FieldOffset(144, 240)]
		public ExternalObject<StageCameraCinebotMode> CinebotMode { get; set; }

		[FieldOffset(148, 248)]
		public ExternalObject<StageMarkEntityData> LookAt { get; set; }

		[FieldOffset(152, 256)]
		public ExternalObject<StageMarkEntityData> LookFrom { get; set; }

		[FieldOffset(156, 264)]
		public float FOV { get; set; }

		[FieldOffset(160, 268)]
		public CameraDofType DofType { get; set; }

		[FieldOffset(164, 272)]
		public DofParameters DofParameters { get; set; }
	}
}
