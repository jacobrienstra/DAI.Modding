using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIStatusEffectTypeSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<UIStatusEffectDisplayInfo> StatusEffectTypeDisplayInfos { get; set; }

		public UIStatusEffectTypeSettings()
		{
			StatusEffectTypeDisplayInfos = new List<UIStatusEffectDisplayInfo>();
		}
	}
}
