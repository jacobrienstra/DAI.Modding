using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class CinebotModeData : CameraModeAsset
	{
		[FieldOffset(12, 72)]
		public float Priority { get; set; }

		[FieldOffset(16, 80)]
		public List<ExternalObject<CinebotControllerRigAsset>> Rigs { get; set; }

		[FieldOffset(20, 88)]
		public ExternalObject<CinebotTransitionData> DefaultTransition { get; set; }

		[FieldOffset(24, 96)]
		public ExternalObject<CinebotSceneAsset> Scene { get; set; }

		[FieldOffset(28, 104)]
		public List<ExternalObject<Dummy>> UserData { get; set; }

		[FieldOffset(32, 112)]
		public ExternalObject<Dummy> Basis { get; set; }

		[FieldOffset(36, 120)]
		public CinebotPointOfView PointOfView { get; set; }

		[FieldOffset(40, 124)]
		public CinebotCameraLocation CameraLocation { get; set; }

		[FieldOffset(44, 128)]
		public ExternalObject<CinebotCameraShotTransitionAsset> Transition { get; set; }

		[FieldOffset(48, 136)]
		public bool IsRealTime { get; set; }

		[FieldOffset(49, 137)]
		public bool CleanStack { get; set; }

		[FieldOffset(50, 138)]
		public bool IsExclusive { get; set; }

		[FieldOffset(51, 139)]
		public bool IsInsertShot { get; set; }

		[FieldOffset(52, 140)]
		public bool InGame { get; set; }

		[FieldOffset(53, 141)]
		public bool IsTargetVisible { get; set; }

		[FieldOffset(54, 142)]
		public bool InheritPriority { get; set; }

		[FieldOffset(55, 143)]
		public bool InheritControllers { get; set; }

		[FieldOffset(56, 144)]
		public bool InheritDefaultTransition { get; set; }

		public CinebotModeData()
		{
			Rigs = new List<ExternalObject<CinebotControllerRigAsset>>();
			UserData = new List<ExternalObject<Dummy>>();
		}
	}
}
