using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIObjectiveTypeSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<UIObjectiveDisplayInfo> ObjectiveTypeDisplayInfos { get; set; }

		public UIObjectiveTypeSettings()
		{
			ObjectiveTypeDisplayInfos = new List<UIObjectiveDisplayInfo>();
		}
	}
}
