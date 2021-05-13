using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SlaveControllerData : CinebotControllerData
	{
		[FieldOffset(24, 112)]
		public float NearPlaneOverride { get; set; }

		[FieldOffset(28, 116)]
		public float FarPlaneOverride { get; set; }

		[FieldOffset(32, 120)]
		public SlaveControllerFocus FocusType { get; set; }

		[FieldOffset(36, 124)]
		public float FocalPlaneOffset { get; set; }

		[FieldOffset(40, 128)]
		public float FocusDistance { get; set; }

		[FieldOffset(44, 132)]
		public float FStop { get; set; }

		[FieldOffset(48, 136)]
		public float MinimumNearBlur { get; set; }

		[FieldOffset(52, 140)]
		public bool UseSlaveTransform { get; set; }

		[FieldOffset(53, 141)]
		public bool UseSlaveFov { get; set; }

		[FieldOffset(54, 142)]
		public bool UseSlaveAnchorPosition { get; set; }

		[FieldOffset(55, 143)]
		public bool UseSlaveLookatPosition { get; set; }

		[FieldOffset(56, 144)]
		public bool UseSlaveNearPlane { get; set; }

		[FieldOffset(57, 145)]
		public bool UseSlaveFarPlane { get; set; }

		[FieldOffset(58, 146)]
		public bool UseSlaveTimeScale { get; set; }
	}
}
