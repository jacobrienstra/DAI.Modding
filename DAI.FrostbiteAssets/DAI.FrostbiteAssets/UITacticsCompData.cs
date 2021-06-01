using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UITacticsCompData : UIComponentData
	{
		[FieldOffset(32, 136)]
		public string ActiveTargetColorHexString { get; set; }

		[FieldOffset(36, 144)]
		public string InactiveTargetColorHexString { get; set; }

		[FieldOffset(40, 152)]
		public ExternalObject<CharacterBehaviorSetting> PlayerAITacticsEnableBehavior { get; set; }

		[FieldOffset(44, 160)]
		public uint PlayerAITacticsEnableChoice { get; set; }

		[FieldOffset(48, 164)]
		public uint PlayerAITacticsDisableChoice { get; set; }

		[FieldOffset(52, 168)]
		public List<ExternalObject<CharacterBehaviorSetting>> PlayerAITacticsBehaviors { get; set; }

		[FieldOffset(56, 176)]
		public LocalizedStringReference CurrentlyControlledPlayerLocString { get; set; }

		public UITacticsCompData()
		{
			PlayerAITacticsBehaviors = new List<ExternalObject<CharacterBehaviorSetting>>();
		}
	}
}
