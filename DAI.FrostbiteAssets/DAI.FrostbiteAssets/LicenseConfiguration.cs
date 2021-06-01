using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class LicenseConfiguration : Asset
	{
		[FieldOffset(12, 72)]
		public List<LicenseInfo> Licenses { get; set; }

		public LicenseConfiguration()
		{
			Licenses = new List<LicenseInfo>();
		}
	}
}
