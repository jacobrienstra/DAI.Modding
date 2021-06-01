using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIBattleMenuSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public ExternalObject<BWDepletableStat> MomentumStat { get; set; }

		[FieldOffset(16, 80)]
		public List<UIBattleMenuSlot> Slots { get; set; }

		public UIBattleMenuSettings()
		{
			Slots = new List<UIBattleMenuSlot>();
		}
	}
}
