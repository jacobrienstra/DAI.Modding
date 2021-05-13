using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIExternalLocStringTranslator : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<UIExternalLocStringIDToLocalizedString> Data { get; set; }

		public UIExternalLocStringTranslator()
		{
			Data = new List<UIExternalLocStringIDToLocalizedString>();
		}
	}
}
