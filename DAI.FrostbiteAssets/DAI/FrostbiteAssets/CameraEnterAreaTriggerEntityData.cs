using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CameraEnterAreaTriggerEntityData : EntityData
	{
		[FieldOffset(16, 96)]
		public UpdatePass UpdatePass { get; set; }

		[FieldOffset(20, 100)]
		public float TimeTreshold { get; set; }

		[FieldOffset(24, 104)]
		public bool AutoStart { get; set; }
	}
}
