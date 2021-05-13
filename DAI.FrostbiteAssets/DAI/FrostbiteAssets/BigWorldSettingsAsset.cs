using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class BigWorldSettingsAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<BigWorldSetting>> Settings { get; set; }

		public BigWorldSettingsAsset()
		{
			Settings = new List<ExternalObject<BigWorldSetting>>();
		}
	}
}
