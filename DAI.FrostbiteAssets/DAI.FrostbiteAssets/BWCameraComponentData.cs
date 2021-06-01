using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class BWCameraComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public string CameraName { get; set; }

		[FieldOffset(100, 184)]
		public int Priority { get; set; }

		[FieldOffset(104, 192)]
		public ExternalObject<CinebotCameraData> Camera { get; set; }

		[FieldOffset(108, 200)]
		public ExternalObject<CinebotModeData> CombatMode { get; set; }

		[FieldOffset(112, 208)]
		public ExternalObject<CinebotModeData> TargetLockMode { get; set; }

		[FieldOffset(116, 216)]
		public List<ExternalObject<DataContainer>> WeaponTypeCameraOverrides { get; set; }

		[FieldOffset(120, 224)]
		public ExternalObject<CinebotModeData> PositionSelectionMode { get; set; }

		[FieldOffset(124, 232)]
		public ExternalObject<CinebotModeData> PauseMode { get; set; }

		[FieldOffset(128, 240)]
		public List<ExternalObject<Dummy>> ExploreModes { get; set; }

		[FieldOffset(132, 248)]
		public bool EnableInMenuLevels { get; set; }

		public BWCameraComponentData()
		{
			WeaponTypeCameraOverrides = new List<ExternalObject<DataContainer>>();
			ExploreModes = new List<ExternalObject<Dummy>>();
		}
	}
}
