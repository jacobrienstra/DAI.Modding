using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class SettingsBundleAsset : Asset
	{
		[FieldOffset(12, 72)]
		public List<ExternalObject<SystemSettings>> Settings { get; set; }

		public SettingsBundleAsset()
		{
			Settings = new List<ExternalObject<SystemSettings>>();
		}
	}
}
