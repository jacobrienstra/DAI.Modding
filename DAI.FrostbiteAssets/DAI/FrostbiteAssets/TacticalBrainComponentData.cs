using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(16)]
	public class TacticalBrainComponentData : TacticalBrainComponentBaseData
	{
		[FieldOffset(128, 224)]
		public ExternalObject<BehaviorTreeData> CombatTactics { get; set; }

		[FieldOffset(132, 232)]
		public int Objective { get; set; }

		[FieldOffset(136, 236)]
		public uint UpdateRate { get; set; }

		[FieldOffset(140, 240)]
		public List<ExternalObject<Dummy>> DefaultBehaviors { get; set; }

		[FieldOffset(144, 248)]
		public List<BehaviorZoneCategory> BehaviorZoneCategoriesToIgnore { get; set; }

		[FieldOffset(148, 256)]
		public List<CharacterBehaviorSettingDefault> CharacterBehaviorSettingDefaults { get; set; }

		public TacticalBrainComponentData()
		{
			DefaultBehaviors = new List<ExternalObject<Dummy>>();
			BehaviorZoneCategoriesToIgnore = new List<BehaviorZoneCategory>();
			CharacterBehaviorSettingDefaults = new List<CharacterBehaviorSettingDefault>();
		}
	}
}
