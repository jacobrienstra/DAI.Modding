using System.Collections.Generic;

namespace DAI.FrostbiteAssets
{
	[DescriptorAlignment(4)]
	public class UIDamageTypeSettings : BWGameplaySettings
	{
		[FieldOffset(12, 72)]
		public List<UIDamageTypeDisplayInfo> DamageTypeDisplayInfos { get; set; }

		public UIDamageTypeSettings()
		{
			DamageTypeDisplayInfos = new List<UIDamageTypeDisplayInfo>();
		}
	}
}
