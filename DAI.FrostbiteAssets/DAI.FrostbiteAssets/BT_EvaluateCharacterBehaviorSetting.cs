using DAI.FrostbiteAssets.Enums;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BT_EvaluateCharacterBehaviorSetting : BTEvalFunc
	{
		[FieldOffset(16, 40)]
		public ExternalObject<CharacterBehaviorSetting> Setting { get; set; }

		[FieldOffset(20, 48)]
		public TacticsTarget Target { get; set; }
	}
}
