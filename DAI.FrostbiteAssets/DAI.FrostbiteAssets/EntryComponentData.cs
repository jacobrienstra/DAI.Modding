using System.Collections.Generic;
using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class EntryComponentData : GameComponentData
	{
		[FieldOffset(96, 176)]
		public Vec3 SoldierOffset { get; set; }

		[FieldOffset(112, 192)]
		public EntryClass EntryClass { get; set; }

		[FieldOffset(116, 200)]
		public ExternalObject<Dummy> AIData { get; set; }

		[FieldOffset(120, 208)]
		public ExternalObject<EntryInputActionMapsData> InputConceptDefinition { get; set; }

		[FieldOffset(124, 216)]
		public ExternalObject<InputActionMappingsData> InputMapping { get; set; }

		[FieldOffset(128, 224)]
		public List<ExternalObject<Dummy>> InputCurves { get; set; }

		[FieldOffset(132, 232)]
		public EntryComponentHudData HudData { get; set; }

		[FieldOffset(144, 244)]
		public int EntryOrderNumber { get; set; }

		[FieldOffset(148, 248)]
		public float EnterImpulse { get; set; }

		[FieldOffset(152, 252)]
		public float EntryRadius { get; set; }

		[FieldOffset(156, 256)]
		public float SoldierTransitionInvisbleTime { get; set; }

		[FieldOffset(160, 260)]
		public int NumberOfStances { get; set; }

		[FieldOffset(164, 264)]
		public EntrySpottingSettings EntrySpottingSettings { get; set; }

		[FieldOffset(168, 272)]
		public ExternalObject<Dummy> EntryComponentSound { get; set; }

		[FieldOffset(172, 280)]
		public int TriggerEventOnKey { get; set; }

		[FieldOffset(176, 284)]
		public bool ForbiddenForHuman { get; set; }

		[FieldOffset(177, 285)]
		public bool IsAllowedToExitInAir { get; set; }

		[FieldOffset(178, 286)]
		public bool IsShielded { get; set; }

		[FieldOffset(179, 287)]
		public bool LockSoldierAimingToEntry { get; set; }

		[FieldOffset(180, 288)]
		public bool ShowSoldierInEntry { get; set; }

		[FieldOffset(181, 289)]
		public bool Show1pSoldierInEntry { get; set; }

		[FieldOffset(182, 290)]
		public bool StancesEnabled { get; set; }

		[FieldOffset(183, 291)]
		public bool ShowSoldierWeaponInEntry { get; set; }

		[FieldOffset(184, 292)]
		public bool Show1pSoldierInEntryForPlayerOnly { get; set; }

		[FieldOffset(185, 293)]
		public bool Show3pSoldierWeaponInEntry { get; set; }

		[FieldOffset(186, 294)]
		public bool ShowSoldierGearInEntry { get; set; }

		[FieldOffset(187, 295)]
		public PoseConstraintsData PoseConstraints { get; set; }

		[FieldOffset(190, 298)]
		public bool AllowRagdollFromEntry { get; set; }

		public EntryComponentData()
		{
			InputCurves = new List<ExternalObject<Dummy>>();
		}
	}
}
