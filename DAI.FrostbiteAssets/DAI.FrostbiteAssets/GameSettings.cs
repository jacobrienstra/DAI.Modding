using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class GameSettings : SystemSettings
	{
		[FieldOffset(16, 40)]
		public uint MaxPlayerCount { get; set; }

		[FieldOffset(20, 44)]
		public uint MaxSpectatorCount { get; set; }

		[FieldOffset(24, 48)]
		public uint MinPlayerCountElimination { get; set; }

		[FieldOffset(28, 52)]
		public LogFileCollisionMode LogFileCollisionMode { get; set; }

		[FieldOffset(32, 56)]
		public uint LogFileRotationHistoryLength { get; set; }

		[FieldOffset(36, 64)]
		public string Level { get; set; }

		[FieldOffset(40, 72)]
		public string StartPoint { get; set; }

		[FieldOffset(44, 80)]
		public List<ExternalObject<GameSettings>> InputConfiguration { get; set; }

		[FieldOffset(48, 88)]
		public TeamId DefaultTeamId { get; set; }

		[FieldOffset(52, 92)]
		public uint PS3ContentRatingAge { get; set; }

		[FieldOffset(56, 96)]
		public uint LogHistory { get; set; }

		[FieldOffset(60, 104)]
		public ExternalObject<Dummy> Version { get; set; }

		[FieldOffset(64, 112)]
		public ExternalObject<Dummy> LayerInclusionTable { get; set; }

		[FieldOffset(68, 120)]
		public string DefaultLayerInclusion { get; set; }

		[FieldOffset(72, 128)]
		public float TimeBeforeSpawnIsAllowed { get; set; }

		[FieldOffset(76, 132)]
		public float LevelWarmUpTime { get; set; }

		[FieldOffset(80, 136)]
		public float TimeToWaitForQuitTaskCompletion { get; set; }

		[FieldOffset(84, 144)]
		public ExternalObject<Dummy> Player { get; set; }

		[FieldOffset(88, 152)]
		public ExternalObject<DifficultyDatas> DifficultySettings { get; set; }

		[FieldOffset(92, 160)]
		public int DifficultyIndex { get; set; }

		[FieldOffset(96, 164)]
		public SKU CurrentSKU { get; set; }

		[FieldOffset(100, 168)]
		public List<ExternalObject<Dummy>> GameSettingsComponents { get; set; }

		[FieldOffset(104, 176)]
		public bool LogFileEnable { get; set; }

		[FieldOffset(105, 177)]
		public bool ResourceRefreshAlwaysAllowed { get; set; }

		[FieldOffset(106, 178)]
		public bool UseSpeedBasedDetailedCollision { get; set; }

		[FieldOffset(107, 179)]
		public bool UseSingleWeaponSelector { get; set; }

		[FieldOffset(108, 180)]
		public bool AutoAimEnabled { get; set; }

		[FieldOffset(109, 181)]
		public bool HasUnlimitedAmmo { get; set; }

		[FieldOffset(110, 182)]
		public bool HasUnlimitedMags { get; set; }

		[FieldOffset(111, 183)]
		public bool RotateLogs { get; set; }

		[FieldOffset(112, 184)]
		public bool AdjustVehicleCenterOfMass { get; set; }

		[FieldOffset(113, 185)]
		public bool AimAssistEnabled { get; set; }

		[FieldOffset(114, 186)]
		public bool AimAssistUsePolynomials { get; set; }

		[FieldOffset(115, 187)]
		public bool ForceFreeStreaming { get; set; }

		[FieldOffset(116, 188)]
		public bool ForceDisableFreeStreaming { get; set; }

		[FieldOffset(117, 189)]
		public bool IsGodMode { get; set; }

		[FieldOffset(118, 190)]
		public bool IsJesusMode { get; set; }

		[FieldOffset(119, 191)]
		public bool IsJesusModeAi { get; set; }

		[FieldOffset(120, 192)]
		public bool GameAdministrationEnabled { get; set; }

		[FieldOffset(121, 193)]
		public bool AllowDestructionOutsideCombatArea { get; set; }

		[FieldOffset(122, 194)]
		public bool DemoMode { get; set; }

		public GameSettings()
		{
			InputConfiguration = new List<ExternalObject<GameSettings>>();
			GameSettingsComponents = new List<ExternalObject<Dummy>>();
		}
	}
}
