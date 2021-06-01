using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class SpawnReferenceObjectData : SpatialReferenceObjectData
	{
		[FieldOffset(112, 256)]
		public LinearTransform ControllableTransform { get; set; }

		[FieldOffset(176, 320)]
		public LinearTransform ControllableInput { get; set; }

		[FieldOffset(240, 384)]
		public ExternalObject<SpawnTemplate> Template { get; set; }

		[FieldOffset(244, 392)]
		public List<ExternalObject<GameObjectData>> ExtraSpawnData { get; set; }

		[FieldOffset(248, 400)]
		public string LocationNameSid { get; set; }

		[FieldOffset(252, 408)]
		public string LocationTextSid { get; set; }

		[FieldOffset(256, 416)]
		public TeamId Team { get; set; }

		[FieldOffset(260, 420)]
		public float InitialSpawnDelay { get; set; }

		[FieldOffset(264, 424)]
		public float SpawnDelay { get; set; }

		[FieldOffset(268, 428)]
		public int MaxCount { get; set; }

		[FieldOffset(272, 432)]
		public int MaxCountSimultaneously { get; set; }

		[FieldOffset(276, 436)]
		public int TotalCountSimultaneouslyOfType { get; set; }

		[FieldOffset(280, 440)]
		public int MaxSpawnInFrame { get; set; }

		[FieldOffset(284, 444)]
		public float SpawnAreaRadius { get; set; }

		[FieldOffset(288, 448)]
		public float SpawnProtectionRadius { get; set; }

		[FieldOffset(292, 452)]
		public uint SpawnProtectionFriendlyKilledCount { get; set; }

		[FieldOffset(296, 456)]
		public float SpawnProtectionFriendlyKilledTime { get; set; }

		[FieldOffset(300, 460)]
		public int TakeControlEntryIndex { get; set; }

		[FieldOffset(304, 464)]
		public float RotationYaw { get; set; }

		[FieldOffset(308, 468)]
		public float RotationPitch { get; set; }

		[FieldOffset(312, 472)]
		public float RotationRoll { get; set; }

		[FieldOffset(316, 476)]
		public float Throttle { get; set; }

		[FieldOffset(320, 480)]
		public TimeDeltaType TimeDeltaType { get; set; }

		[FieldOffset(324, 484)]
		public bool SaveState { get; set; }

		[FieldOffset(325, 485)]
		public bool CacheLinkArray { get; set; }

		[FieldOffset(326, 486)]
		public bool Enabled { get; set; }

		[FieldOffset(327, 487)]
		public bool LockedTeam { get; set; }

		[FieldOffset(328, 488)]
		public bool InitialAutoSpawn { get; set; }

		[FieldOffset(329, 489)]
		public bool AutoSpawn { get; set; }

		[FieldOffset(330, 490)]
		public bool QueueSpawnEvent { get; set; }

		[FieldOffset(331, 491)]
		public bool UseAsSpawnPoint { get; set; }

		[FieldOffset(332, 492)]
		public bool SpawnProtectionCheckAllTeams { get; set; }

		[FieldOffset(333, 493)]
		public bool ClearBangersOnSpawn { get; set; }

		[FieldOffset(334, 494)]
		public bool OnlySendEventForHumanPlayers { get; set; }

		[FieldOffset(335, 495)]
		public bool SendWeaponEvents { get; set; }

		[FieldOffset(336, 496)]
		public bool TryToSpawnOutOfSight { get; set; }

		[FieldOffset(337, 497)]
		public bool TakeControlOnTransformChange { get; set; }

		[FieldOffset(338, 498)]
		public bool ReturnControlOnIdle { get; set; }

		public SpawnReferenceObjectData()
		{
			ExtraSpawnData = new List<ExternalObject<GameObjectData>>();
		}
	}
}
